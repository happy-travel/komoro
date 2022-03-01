using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

public class HotelProductsRS
{
    [XmlAttribute]
    public string HotelCode { get; set; } = string.Empty;

    /// <summary>
    /// List of hotel products for a given hotel. Can be omitted if no valid products exist for this hotel.
    /// </summary>
    public List<HotelProduct> HotelProducts { get; set; } = null!;
}
