using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts;

/// <summary>
/// The Hotel Products request is used to obtain a list of all valid room type and rate plan combinations for a given hotel. This information will be
/// used to map TravelClick’s internal codes with the OTA partner’s own room and rate plan codes.
/// The request contains the hotel ID for the desired hotel. There is only one hotel specified per request.
/// </summary>
[XmlRoot(ElementName = "OTA_HotelProductRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public class OtaHotelProductRQ : BaseRequest
{
    /// <summary>
    /// Point of Sale. TravelClick will only send this information if specifically requested by OTA partner.
    /// </summary>
    [XmlElement(ElementName = "POS")]
    public Pos? Pos { get; set; } = new();

    /// <summary>
    /// Hotel products
    /// </summary>
    public HotelProduct[] HotelProducts { get; set; } = new HotelProduct[1];
}
