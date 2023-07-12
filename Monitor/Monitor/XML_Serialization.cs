using System.IO;
using System.Xml.Serialization;

namespace Monitor;

public class XML_Serialization
{
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Store));

    public void StoreSerialize(Store store)
    {
        using FileStream fileStream = new FileStream("Store.xml",FileMode.OpenOrCreate);
        xmlSerializer.Serialize(fileStream, store);
    }

}