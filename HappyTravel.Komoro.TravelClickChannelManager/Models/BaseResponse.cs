using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

public record BaseResponse
{
    [XmlAttribute]
    public string Version { get; init; } = string.Empty;

    [XmlAttribute]
    public DateTime TimeStamp { get; init; }

    [XmlAttribute]
    public string EchoToken { get; init; } = string.Empty;

    /// <summary>
    /// Empty element to indicate that the request was successful. Required to indicate success, but expected to be omitted when there are errors.
    /// </summary>
    public Success? Success { get; init; }
}
