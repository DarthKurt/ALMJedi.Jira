using System.IO;
using LiteDB;
using Microsoft.Extensions.Configuration;

namespace Jira.BackSync.Storage.Configuration
{
    /// <summary>
    /// A LiteDb file based <see cref="FileConfigurationProvider"/>.
    /// </summary>
    public class LiteDbConfigurationProvider : FileConfigurationProvider
    {
        private readonly string _configurationCollectionName;

        /// <summary>
        /// Initializes a new instance with the specified source.
        /// </summary>
        /// <param name="source">The source settings.</param>
        /// <param name="configurationCollectionName">Name of the collection to store configuration documents</param>
        public LiteDbConfigurationProvider(LiteDbConfigurationSource source, string configurationCollectionName)
            : base(source)
        {
            _configurationCollectionName = configurationCollectionName;
        }

        /// <summary>
        /// Loads the JSON data from a stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        public override void Load(Stream stream)
        {
            using (var db = new LiteDatabase(stream))
            {
                var parser = new LiteDbConfigurationParser();
                Data = parser.Parse(db, _configurationCollectionName);
            }
        }
    }
}