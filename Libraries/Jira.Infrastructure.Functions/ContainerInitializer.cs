using System.Collections.Generic;
using Autofac;
using Microsoft.Extensions.Logging;

namespace Jira.Infrastructure.Functions
{
    public class ContainerInitializer
    {
        private readonly ILoggerFactory _loggerFactory;
        private IContainer _container;

        public ContainerInitializer(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public IContainer GetOrCreateContainer()
        {
            if (_container == null)
            {
                InitializeContainer();
            }

            return _container;
        }

        private void InitializeContainer()
        {
            var moduleCollector = new ModuleCollector();
            var containerBuilder = new ContainerBuilder();
            RegisterModules(moduleCollector.GetModules(), containerBuilder);
            RegisterLoggingFactory(_loggerFactory, containerBuilder);
            _container = containerBuilder.Build();
        }

        private static void RegisterLoggingFactory(ILoggerFactory loggerFactory, ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterInstance(loggerFactory);
        }

        private static void RegisterModules(IEnumerable<Module> modules, ContainerBuilder containerBuilder)
        {
            foreach (var module in modules)
            {
                containerBuilder.RegisterModule(module);
            }
        }
    }
}