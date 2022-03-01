using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;

/// <summary>
/// Hotel product
/// </summary>
public class HotelProduct
{
    /// <summary>
    /// Hotel identifier used to look up products
    /// </summary>
    [XmlAttribute]
    public string HotelCode { get; set; } = string.Empty;
}
