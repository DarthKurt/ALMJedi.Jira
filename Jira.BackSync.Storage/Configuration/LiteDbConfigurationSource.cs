using Microsoft.Extensions.Configuration;

namespace JiraBackSync.Storage.Configuration
{
    /// <summary>
    /// Represents a LiteDb file as an <see cref="IConfigurationSource"/>.
    /// </summary>
    public class LiteDbConfigurationSource : FileConfigurationSource
    {
        /// <summary>
        /// Name of the collection to store configuration documents
        /// </summary>
        public string ConfigurationCollectionName { get; set; }

        /// <summary>
        /// Builds the <see cref="LiteDbConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>A <see cref="LiteDbConfigurationProvider"/></returns>
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new LiteDbConfigurationProvider(this, ConfigurationCollectionName);
        }
    }
}