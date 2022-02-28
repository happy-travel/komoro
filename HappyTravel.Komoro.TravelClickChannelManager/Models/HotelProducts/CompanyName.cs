using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts;

/// <summary>
/// OTA partner name. The OTA partner needs to provide what value they expect to be send by TravelClick.
/// </summary>
public class CompanyName
{
    [XmlText]
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// OTA partner identifier. The OTA partner needs to provide what value they expect to be send by TravelClick.
    /// </summary>
    [XmlAttribute]
    public string Code { get; set; } = string.Empty;
}
