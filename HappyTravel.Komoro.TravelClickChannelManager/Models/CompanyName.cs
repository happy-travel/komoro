using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

/// <summary>
/// OTA partner name. The OTA partner needs to provide what value they expect to be send by TravelClick.
/// </summary>
public record CompanyName
{
    [XmlText]
    public string Name { get; init; } = string.Empty;
    
    /// <summary>
    /// OTA partner identifier. The OTA partner needs to provide what value they expect to be send by TravelClick.
    /// </summary>
    [XmlAttribute]
    public string Code { get; init; } = string.Empty;
}
