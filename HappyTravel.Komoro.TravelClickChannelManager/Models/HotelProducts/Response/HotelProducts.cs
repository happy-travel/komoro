using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

/// <summary>
/// List of hotel products for a given hotel. Can be omitted if no valid products exist for this hotel.
/// </summary>
public class HotelProducts : List<HotelProduct>
{
    [XmlAttribute]
    public string HotelCode { get; set; } = string.Empty;
}
