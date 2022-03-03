using System.IO;
using System.Xml.Serialization;

namespace HappyTravel.Komoro.UnitTests.Infrastructure;

internal static class SerializationHelper
{
    public static string SerializeAndSave<T>(T data)
    {
        var fileName = $"{typeof(T)}.xml";
        var xmlSerializer = new XmlSerializer(typeof(T));
        var streamWriter = new StreamWriter(fileName);
        xmlSerializer.Serialize(streamWriter, data);
        streamWriter.Close();

        return fileName;
    }
}
