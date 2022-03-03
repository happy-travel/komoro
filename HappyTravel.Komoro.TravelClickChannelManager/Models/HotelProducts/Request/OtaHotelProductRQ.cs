using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;

/// <summary>
/// The Hotel Products request is used to obtain a list of all valid room type and rate plan combinations for a given hotel. This information will be
/// used to map TravelClick’s internal codes with the OTA partner’s own room and rate plan codes.
/// The request contains the hotel ID for the desired hotel. There is only one hotel specified per request.
/// </summary>
[XmlRoot(ElementName = "OTA_HotelProductRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelProductRQ : BaseRequest
{
    /// <summary>
    /// Point of Sale. TravelClick will only send this information if specifically requested by OTA partner.
    /// </summary>
    [XmlElement(ElementName = "POS")]
    public Pos? Pos { get; init; }

    /// <summary>
    /// List of hotel products for a given hotel. Can be omitted if no valid products exist for this hotel.
    /// </summary>
    public List<HotelProduct> HotelProducts { get; init; } = new(1);
}
