using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Ping;

/// <summary>
/// A successful Ping response contains both a Success element and an EchoData element matching the content of the EchoData from the original request. 
/// When this response is received, it is assumed that the web service is available to accept further requests.
/// However, if a non-200 HTTP response is received, or if the OTA_PingRS body contains an Errors element, it is assumed that the web service is not 
/// available and should therefore not receive any other non-Ping requests.
/// </summary>
[XmlRoot(ElementName = "OTA_PingRS", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaPingRS
{
    [XmlAttribute]
    public string Version { get; init; } = string.Empty;

    [XmlAttribute]
    public DateTime TimeStamp { get; init; }

    /// <summary>
    /// Empty element to indicate that the request was successful. Required to indicate success, but expected to be omitted when there are errors.
    /// </summary>
    public Success? Success { get; init; }

    /// <summary>
    /// String echoed from original request
    /// </summary>
    public string EchoData { get; init; } = string.Empty;
}
