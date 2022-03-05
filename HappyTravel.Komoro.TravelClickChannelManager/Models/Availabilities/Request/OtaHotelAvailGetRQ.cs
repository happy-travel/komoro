using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Get Availability Restrictions
/// Request is initiated by TravelClick
/// The OTA_HotelAvailGetRQ is used to fetch the current availability restrictions for a given date range and product(s). Each HotelAvailRequest 
/// contains a list of rate plan codes and room type codes.The response should include all valid products that match the cross product of the 
/// RatePlanCandidates list and the RoomTypeCandidates list.
/// </summary>
[XmlRoot(ElementName = "OTA_HotelAvailGetRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelAvailGetRQ : BaseRequest
{
    /// <summary>
    /// Point of Sale. TravelClick will only send this information if specifically requested by OTA partner.
    /// </summary>
    [XmlElement(ElementName = "POS")]
    public Pos Pos { get; init; } = null!;

    /// <summary>
    /// List of inventory updates for the given hotel
    /// </summary>
    public List<HotelAvailRequest> HotelAvailRequests { get; init; } = null!;
}
