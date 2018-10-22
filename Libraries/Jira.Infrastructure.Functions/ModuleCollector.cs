using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Jira.Core.IoC;

namespace Jira.Infrastructure.Functions
{
    public class ModuleCollector
    {
        private static Type GetBootstrapper()
        {
            // System and Microsoft assemblies will never contain any relevant class, so it is sensible to skip them anyway.
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => !x.GetName().Name.StartsWith("System.") && !x.GetName().Name.StartsWith("Microsoft."))
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(x => typeof(IBootstrapper).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
        }

        public IEnumerable<Module> GetModules()
        {
            var bootstrapper = GetBootstrapper() ?? throw new Exception("Failed to bootstrap application");

            var instance = (IBootstrapper)Activator.CreateInstance(bootstrapper);
            return instance.CreateModules();
        }
    }
}