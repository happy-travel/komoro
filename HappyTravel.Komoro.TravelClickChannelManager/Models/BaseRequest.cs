using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

public record BaseRequest
{
    [XmlAttribute]
    public string Version { get; init; } = string.Empty;

    [XmlAttribute]
    public DateTime TimeStamp { get; init; }

    [XmlAttribute]
    public string EchoToken { get; init; } = string.Empty;
}
