using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using JiraBackSync.Core.Utils;
using JiraBackSync.Storage.Data;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace JiraBackSync.Storage
{
    /// <summary>
    /// An XML repository backed by a file system.
    /// </summary>
    public class LiteDbXmlStorage : IXmlStorage
    {
        public ILoggerFactory LoggerFactory { get; set; }

        private readonly string _filesFolder;
        private readonly string _path;

        /// <summary>
        /// Creates a <see cref="LiteDbXmlStorage"/> with keys stored at the given directory.
        /// </summary>
        /// <param name="filesFolder">String prefix for xml key files in LiteDB</param>
        /// <param name="path">Path to the LiteDb file</param>
        public LiteDbXmlStorage(string filesFolder, string path)
        {
            _filesFolder = filesFolder;
            _path = path;
        }

        public virtual IReadOnlyCollection<XElement> GetAllElements()
        {
            // forces complete enumeration
            return GetAllElementsCore().ToList().AsReadOnly();
        }

        private IEnumerable<XElement> GetAllElementsCore()
        {
            using (var db = new LiteDatabase(_path))
            {
                foreach (var file in db.FileStorage.Find(_filesFolder))
                {
                    var element = ReadElementFromFile(file);
                    if (element == null)
                        continue;
                    yield return element;
                }
            }
        }

        public virtual void StoreElement(XElement element, string friendlyName)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (!IsSafeFilename(friendlyName))
            {
                var logger = LoggerFactory?.CreateLogger<LiteDbXmlStorage>();

                var newFriendlyName = Guid.NewGuid().ToString();
                logger?.LogInformation($"The name '{friendlyName}' is not a safe file name, using '{newFriendlyName}' instead.");
                friendlyName = newFriendlyName;
            }

            StoreElementCore(element, friendlyName);
        }

        #region Private

        private static bool IsSafeFilename(string filename)
        {
            // Must be non-empty and contain only a-zA-Z0-9, hyphen, and underscore.
            return (!string.IsNullOrEmpty(filename) && filename.All(c =>
                        c == '-'
                        || c == '_'
                        || ('0' <= c && c <= '9')
                        || ('A' <= c && c <= 'Z')
                        || ('a' <= c && c <= 'z')));
        }

        private XElement ReadElementFromFile(LiteFileInfo fileInfo)
        {
            using (var fileStream = fileInfo.OpenRead())
            {
                try
                {
                    return XElement.Load(fileStream);
                }
                catch (XmlException e)
                {
                    var logger = LoggerFactory?.CreateLogger<LiteDbXmlStorage>();
                    logger?.LogError($"The key file '{fileInfo.Filename}' is corrupted.\nSee details:\n{e}");
                    return null;
                }
            }
        }

        private void StoreElementCore(XElement element, string filename)
        {
            var logger = LoggerFactory?.CreateLogger<LiteDbXmlStorage>();

            try
            {
                using (var fs = new FStream())
                {
                    var xws = new XmlWriterSettings
                    {
                        OmitXmlDeclaration = true,
                        Indent = true
                    };

                    using (var xw = XmlWriter.Create(fs, xws))
                    {
                        var doc = new XDocument(element);
                        doc.WriteTo(xw);
                    }

                    var ext = Path.GetExtension(filename);
                    if (!ext.Equals("xml"))
                        filename = $"{Path.GetFileNameWithoutExtension(filename)}.xml";

                    var path = Path.Combine(_filesFolder, filename);
                    using (var db = new LiteDatabase(_path))
                    {
                        db.FileStorage.Upload(path, filename, fs);
                    }
                }
            }
            catch (Exception e)
            {
                logger?.LogError(e.ToString());
            }
        }

        #endregion

    }
}