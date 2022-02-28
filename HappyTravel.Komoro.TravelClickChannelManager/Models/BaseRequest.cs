using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

public class BaseRequest
{
    [XmlAttribute]
    public string Version { get; set; } = string.Empty;

    [XmlAttribute]
    public DateTime TimeStamp { get; set; }

    [XmlAttribute]
    public string EchoToken { get; set; } = string.Empty;
}
