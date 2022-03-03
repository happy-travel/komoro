using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

/// <summary>
/// List of hotel products for a given hotel. Can be omitted if no valid products exist for this hotel.
/// </summary>
[XmlType(TypeName = "HotelProducts")]
public record HotelProducts
{
    /// <summary>
    /// Hotel identifier
    /// </summary>
    [XmlAttribute]
    public string HotelCode { get; init; } = string.Empty;

    [XmlElement(ElementName = "HotelProduct")]
    public List<HotelProduct> HotelProductList { get; init; } = null!;
}
