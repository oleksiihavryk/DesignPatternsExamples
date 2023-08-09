using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AbstractFactoryPattern;
internal class XmlDataFactory : DataFactory
{
    public override XmlData CreateData<T>(T obj) where T : class
    {
        var serializer = new XmlSerializer(typeof(T));
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);

        serializer.Serialize(writer, obj);

        var buffer = new byte[stream.Length];
        stream.Position = 0;
        while (stream.Read(buffer) != 0) ;

        var xml = Encoding.UTF8.GetString(buffer);

        return new XmlData(xml);
    }
}