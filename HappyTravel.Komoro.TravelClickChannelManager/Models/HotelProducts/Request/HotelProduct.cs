using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;

/// <summary>
/// Hotel product
/// </summary>
public record HotelProduct
{
    /// <summary>
    /// Hotel identifier used to look up products
    /// </summary>
    [XmlAttribute]
    public string HotelCode { get; init; } = string.Empty;
}
