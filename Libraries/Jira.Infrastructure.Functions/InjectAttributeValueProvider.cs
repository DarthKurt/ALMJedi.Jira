using System;
using System.Reflection;
using System.Threading.Tasks;
using Jira.Core.IoC;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Jira.Infrastructure.Functions
{
    internal class InjectAttributeValueProvider : IValueProvider
    {
        private readonly ParameterInfo _parameterInfo;
        private readonly IObjectResolver _objectResolver;

        public InjectAttributeValueProvider(ParameterInfo parameterInfo, IObjectResolver objectResolver)
        {
            _parameterInfo = parameterInfo;
            _objectResolver = objectResolver;
        }

        public Task<object> GetValueAsync()
        {
            var injectAttribute = _parameterInfo.GetCustomAttribute<InjectAttribute>();

            return Task.FromResult(injectAttribute.HasName
                ? _objectResolver.Resolve(Type, injectAttribute.Name)
                : _objectResolver.Resolve(Type));
        }

        public string ToInvokeString()
        {
            return Type.ToString();
        }

        public Type Type => _parameterInfo.ParameterType;
    }
}