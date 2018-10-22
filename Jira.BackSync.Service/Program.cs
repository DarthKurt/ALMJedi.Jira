using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Jira.BackSync.Core;
using Jira.BackSync.Core.Utils;
using Jira.BackSync.Jira;
using Jira.BackSync.Jira.Configuration;
using Jira.BackSync.Security;
using Jira.BackSync.Security.Configuration;
using Jira.BackSync.Service.Configuration;
using Jira.BackSync.Service.Load;
using Jira.BackSync.Service.Sync;
using Jira.BackSync.Storage;
using Jira.BackSync.Storage.Configuration;
using Jira.BackSync.TMetric;
using Jira.BackSync.TMetric.Configuration;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Jira.BackSync.Service
{
    internal class Program
    {
        private static IServiceProvider ServiceProvider { get; set; }
        private static IXmlStorage XmlStorage { get; set; }

        private static void Main()
        {
            var xmlStorage = new LiteDbXmlStorage(SharedConfiguration.XmlKeysFolderPath, SharedConfiguration.DbName);
            XmlStorage = xmlStorage;
            ConfigureServiceCollection();

            //configure console logging
            ServiceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var loggerFactory = ServiceProvider.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Starting application...");

            // other initialization
            xmlStorage.LoggerFactory = loggerFactory;
            logger.LogInformation("Started.");

            try
            {
                var sync = ServiceProvider.GetService<ISyncService>();
                sync.RunAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                logger.LogCritical(e.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static void ConfigureServiceCollection()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging();

            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddLiteDbFile(SharedConfiguration.DbName, SharedConfiguration.ConfigurationCollectionName)
                .Build();

            serviceCollection.AddOptions();

            var eso = configuration.GetSection("EncryptionServiceConfiguration");

            serviceCollection.Configure<TimeUtilsOptions>(configuration.GetSection("TimeUtilsConfiguration"));
            serviceCollection.Configure<TimeEntryAggregatorOptions>(configuration.GetSection("TimeEntryAggregatorConfiguration"));
            serviceCollection.Configure<UploaderServiceOptions>(configuration.GetSection("UploaderConfiguration"));

            serviceCollection.Configure<EncryptionServiceOptions>(eso);

            var tmb = eso["Thumbprint"];

            if (!string.IsNullOrWhiteSpace(tmb))
            {
                var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                try
                {
                    store.Open(OpenFlags.ReadOnly);
                    var matching = store.Certificates.Find(
                        X509FindType.FindByThumbprint,
                        tmb, false);

                    if (matching.Count > 0)
                    {
                        serviceCollection.AddDataProtection()
                            .SetDefaultKeyLifetime(TimeSpan.FromDays(365))
                            .PersistKeysToCustomXmlRepository(
                                new DataProtectionXmlRepository(XmlStorage))
                            .ProtectKeysWithCertificate(matching[0]);
                    }
                }
                finally
                {
                    store.Close();
                }
            }

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);

            // Make your Autofac registrations. Order is important!
            // If you make them BEFORE you call Populate, then the
            // registrations in the ServiceCollection will override Autofac
            // registrations; if you make them AFTER Populate, the Autofac
            // registrations will override. You can make registrations
            // before or after Populate, however you choose.
            containerBuilder.RegisterType<TimeEntryAggregator>().As<ITimeEntryAggregator>();
            containerBuilder.RegisterType<TimeUtils>().As<ITimeUtils>();
            containerBuilder.RegisterType<TmetricLoadService>().As<ILoadService>();
            containerBuilder.RegisterType<LiteDbPasswordStorage>()
                .WithParameters(new List<Parameter>
                    {
                        new NamedParameter("collectionName", SharedConfiguration.PasswordStorage),
                        new NamedParameter("path", SharedConfiguration.DbName)
                    })
                .As<IPasswordStorage>();
            containerBuilder.RegisterType<SecurityService>().As<ISecurityService>();
            containerBuilder.RegisterType<Uploader>().As<IUploader>();
            containerBuilder.RegisterType<SyncService>().As<ISyncService>();

            //containerBuilder.RegisterType<Storage>();

            ServiceProvider = new AutofacServiceProvider(containerBuilder.Build());

            //using (var db = new LiteDatabase(SharedConfiguration.DbName))
            //{
            //    var col = db.GetCollection("Configuration");
            //    col.Insert("UploaderConfiguration", BsonMapper.Global.ToDocument(new UploaderServiceOptions
            //    {
            //        BaseApiUrl = "https://owl.cbsi.com/jira",
            //        UserName = "epopodyanets"
            //    }));
            //}
        }
    }
}