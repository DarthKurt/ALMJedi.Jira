using System.Collections.Generic;
using System.Xml.Linq;
using JiraBackSync.Core.Utils;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace JiraBackSync.Security
{
    public class DataProtectionXmlRepository: IXmlRepository
    {
        private readonly IXmlStorage _storage;

        public DataProtectionXmlRepository(IXmlStorage storage)
        {
            _storage = storage;
        }

        public IReadOnlyCollection<XElement> GetAllElements()
        {
            return _storage.GetAllElements();
        }

        public void StoreElement(XElement element, string friendlyName)
        {
            _storage.StoreElement(element, friendlyName);
        }
    }
}