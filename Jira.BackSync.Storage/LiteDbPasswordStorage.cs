using Jira.BackSync.Core.Utils;
using Jira.BackSync.Storage.Data;
using LiteDB;

namespace Jira.BackSync.Storage
{
    /// <summary>
    /// An XML repository backed by a file system.
    /// </summary>
    public class LiteDbPasswordStorage : IPasswordStorage
    {
        private readonly string _collectionName;
        private readonly string _path;

        /// <summary>
        /// Creates a <see cref="LiteDbXmlStorage"/> with keys stored at the given directory.
        /// </summary>
        /// <param name="collectionName">String prefix for xml key files in LiteDB</param>
        /// <param name="path">Path to the LiteDb file</param>
        public LiteDbPasswordStorage(string collectionName, string path)
        {
            _collectionName = collectionName;
            _path = path;
        }

        public void Save(string key, byte[] toSave)
        {
            var mapper = BsonMapper.Global;
            mapper.Entity<PasswordEntry>().Id(x => x.Key);

            using (var db = new LiteDatabase(_path, mapper))
            {
                var collection = db.GetCollection<PasswordEntry>(_collectionName);
                if(collection.Exists(p => p.Key.Equals(key)))
                {
                    collection.Update(new PasswordEntry(toSave, key));
                }
                else
                {
                    collection.Insert(new PasswordEntry(toSave, key));
                }
            }
        }

        public byte[] Load(string key)
        {
            var mapper = BsonMapper.Global;
            mapper.Entity<PasswordEntry>().Id(x => x.Key);

            using (var db = new LiteDatabase(_path, mapper))
            {
                var collection = db.GetCollection<PasswordEntry>(_collectionName);
                return collection.FindOne(p => p.Key.Equals(key))?.Data;
            }
        }
    }
}