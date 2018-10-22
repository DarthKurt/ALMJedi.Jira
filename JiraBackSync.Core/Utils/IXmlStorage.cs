using System.Collections.Generic;
using System.Xml.Linq;

namespace JiraBackSync.Core.Utils
{
    public interface IXmlStorage
    {
        IReadOnlyCollection<XElement> GetAllElements();

        void StoreElement(XElement element, string friendlyName);
    }
}