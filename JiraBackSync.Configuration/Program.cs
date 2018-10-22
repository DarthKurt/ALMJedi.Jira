using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using JiraBackSync.Core;
using JiraBackSync.Core.Utils;
using JiraBackSync.Security;
using JiraBackSync.Security.Configuration;
using JiraBackSync.Storage;
using JiraBackSync.Storage.Configuration;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace JiraBackSync.Configuration
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();

            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddLiteDbFile(SharedConfiguration.DbName, SharedConfiguration.ConfigurationCollectionName)
                .AddCommandLine(args)
                .Build();

            var xmlStorage = new LiteDbXmlStorage(SharedConfiguration.XmlKeysFolderPath, SharedConfiguration.DbName);

            var eso = configuration.GetSection("EncryptionServiceConfiguration");

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
                                new DataProtectionXmlRepository(xmlStorage))
                            .ProtectKeysWithCertificate(matching[0]);
                    }
                }
                finally
                {
                    store.Close();
                }
            }

            serviceCollection.AddTransient<ISecurityService, SecurityService>();
            serviceCollection.AddTransient<IConsole, ExtendedConsole>();
            serviceCollection.AddTransient<IPasswordStorage, LiteDbPasswordStorage>(
                p => new LiteDbPasswordStorage(SharedConfiguration.PasswordStorage, SharedConfiguration.DbName));

            //containerBuilder.RegisterType<Storage>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            //configure console logging
            serviceProvider.GetService<ILoggerFactory>().AddConsole(LogLevel.Debug);

            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<Program>();
            var console = serviceProvider.GetService<IConsole>();

            xmlStorage.LoggerFactory = loggerFactory;
            try
            {
                var pwd = console.ReadPassword("Enter the password:", "Password is saving...");
                var encryptionService = serviceProvider.GetService<ISecurityService>();
                encryptionService.PersistPassword("JiraPassword", pwd);
                logger.LogInformation("Saved.");
            }
            catch (Exception e)
            {
                logger.LogCritical(e.ToString());
            }
            finally
            {
                console.ReadLine();
            }
        }
    }
}