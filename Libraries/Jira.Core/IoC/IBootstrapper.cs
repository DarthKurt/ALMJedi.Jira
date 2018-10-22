using System.Collections.Generic;
using Autofac;

namespace Jira.Core.IoC
{
    public interface IBootstrapper
    {
        IEnumerable<Module> CreateModules();
    }
}