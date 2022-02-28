using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

public class BaseResponse
{
    [XmlAttribute]
    public string Version { get; set; } = string.Empty;

    [XmlAttribute]
    public DateTime TimeStamp { get; set; }

    [XmlAttribute]
    public string EchoToken { get; set; } = string.Empty;

    /// <summary>
    /// Empty element to indicate that the request was successful. Required to indicate success, but expected to be omitted when there are errors.
    /// </summary>
    public Success? Success { get; set; }
}
