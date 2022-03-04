using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Get Inventory
/// Request is initiated by TravelClick
/// The OTA_HotelInvCountRQ is used to fetch the current inventory for a given date range and room(s). Each HotelInvCountRequest contains a list of 
/// room type codes under RoomTypeCandidates.The response should include all valid products for the rooms in the RoomTypeCandidates list.
/// We support two types of inventory counts: Available(@CountType= "2") and Booked(@CountType= "4"). Only the former is required.Inventory counts 
/// of @CountType = "4" are optional.
/// </summary>
[XmlRoot(ElementName = "OTA_HotelInvCountRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelInvCountRQ
{
    /// <summary>
    /// Point of Sale. TravelClick will only send this information if specifically requested by OTA partner.
    /// </summary>
    [XmlElement(ElementName = "POS")]
    public Pos Pos { get; init; } = null!;

    /// <summary>
    /// List of hotel inventory count requests
    /// </summary>
    public List<HotelInvCountRequest> HotelInvCountRequests { get; init; } = null!;
}
