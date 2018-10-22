using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;

namespace Jira.Infrastructure.Functions
{
    public class InjectAttributeExtensionConfigProvider : IExtensionConfigProvider
    {
        private InjectAttributeBindingProvider _bindingProvider;
        private readonly ILoggerFactory _loggerFactory;

        public InjectAttributeExtensionConfigProvider(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            _bindingProvider = new InjectAttributeBindingProvider(_loggerFactory);
            context.AddBindingRule<InjectAttribute>().Bind(_bindingProvider);
        }
    }
}