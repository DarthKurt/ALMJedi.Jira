using System.Collections.Generic;
using System.Xml.Linq;

namespace Jira.BackSync.Core.Utils
{
    public interface IXmlStorage
    {
        IReadOnlyCollection<XElement> GetAllElements();

        void StoreElement(XElement element, string friendlyName);
    }
}