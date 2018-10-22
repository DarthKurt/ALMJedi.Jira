using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using Microsoft.Extensions.Configuration;

namespace Jira.BackSync.Storage.Configuration
{
    internal class LiteDbConfigurationParser
    {
        private const string IdPropertyName = "_id";

        private readonly IDictionary<string, string> _data =
            new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        private readonly Stack<string> _context = new Stack<string>();
        private string _currentPath;

        public IDictionary<string, string> Parse(LiteDatabase db, string collectionName)
        {
            _data.Clear();

            var collection = db.GetCollection(collectionName);

            VisitCollection(collection);

            return _data;
        }

        private void VisitCollection(LiteCollection<BsonDocument> collection)
        {
            foreach (var document in collection.FindAll())
            {
                if (document.ContainsKey(IdPropertyName))
                    EnterContext(document[IdPropertyName]);
                else
                    continue;

                VisitDocument(document);
                ExitContext();
            }
        }

        private void VisitDocument(BsonDocument document)
        {
            foreach (var key in document.Keys.Where(k => !k.Equals(IdPropertyName)))
            {
                var v = document[key];
                VisitValue(v, key);
            }
        }

        private void VisitValue(BsonValue value, string key)
        {
            EnterContext(key);

            try
            {
                switch (value)
                {
                    case var v when v.IsDocument:
                            VisitDocument(v.AsDocument);
                        break;
                    case var v when v.IsArray:
                            var a = v.AsArray;
                            VisitArray(a);
                        break;
                    default:
                        _data[_currentPath] = value.AsString;
                        break;
                }
            }
            catch
            {
                // ignored
            }
            finally
            {
                ExitContext();
            }
        }

        private void VisitArray(BsonArray value)
        {
            for (var index = 0; index < value.Count; index++)
            {
                VisitValue(value[index], index.ToString());
            }
        }

        private void EnterContext(string context)
        {
            _context.Push(context);
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }

        private void ExitContext()
        {
            _context.Pop();
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }
    }
}