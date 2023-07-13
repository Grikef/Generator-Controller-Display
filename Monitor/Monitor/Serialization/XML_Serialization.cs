using System.IO;
using System.Xml.Serialization;

namespace Monitor;

public class XML_Serialization
{
    private XmlSerializer xmlSerializer;

    public void StoreSerialize(Store.Net store)
    {
        xmlSerializer = new XmlSerializer(store.GetType());
        using FileStream fileStream = new FileStream("Store.xml",FileMode.Create);
        xmlSerializer.Serialize(fileStream, store);
    }

    public void StoreSerialize(Store.Net store, string path)
    {
        using FileStream fileStream = new FileStream(path, FileMode.Create);
        xmlSerializer.Serialize(fileStream, store);

    }

    public Store.Net DeserializeNet(string path)
    {
        xmlSerializer = new XmlSerializer(typeof(Store.Net));

        using FileStream fileStream = new FileStream(path, FileMode.Open);
        return (Store.Net)xmlSerializer.Deserialize(fileStream)!;
    }

    public Store.Engine DeserializeEngine(string path)
    {
        xmlSerializer = new XmlSerializer(typeof(Store.Engine));
        using FileStream fileStream = new FileStream(path, FileMode.Open);
        
        return (Store.Engine)xmlSerializer.Deserialize(fileStream)!;
    }
    public Store.Generator DeserializeGenerator(string path)
    {
        xmlSerializer = new XmlSerializer(typeof(Store.Generator));

        using FileStream fileStream = new FileStream(path, FileMode.Open);
        return (Store.Generator)xmlSerializer.Deserialize(fileStream)!;
    }
}