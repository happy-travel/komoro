using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

/// <summary>
/// The response contains a series of HotelProduct elements. Each of these contains a list of RatePlan and RoomType elements as shown below. 
/// The response is interpreted to mean that the cross product of every rate plan and every room type within a HotelProduct element represents 
/// a valid product.
/// </summary>
[XmlRoot(ElementName = "OTA_HotelProductRS", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelProductRS : BaseResponse
{
    /// <summary>
    /// List of hotel products for a given hotel. Can be omitted if no valid products exist for this hotel.
    /// </summary>
    [XmlElement]
    public HotelProducts? HotelProducts { get; set; }
}
