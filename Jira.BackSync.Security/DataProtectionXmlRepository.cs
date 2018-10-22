using System.Collections.Generic;
using System.Xml.Linq;
using Jira.BackSync.Core.Utils;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace Jira.BackSync.Security
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