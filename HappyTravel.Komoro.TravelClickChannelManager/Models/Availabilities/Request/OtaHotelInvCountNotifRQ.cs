using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Update inventory
/// Request is initiated by TravelClick
/// An inventory update request specifies the number of available rooms for the given product(s).
/// </summary>
[XmlRoot(ElementName = "OTA_HotelInvCountNotifRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelInvCountNotifRQ : BaseRequest
{
    /// <summary>
    /// Point of Sale. TravelClick will only send this information if specifically requested by OTA partner.
    /// </summary>
    [XmlElement(ElementName = "POS")]
    public Pos Pos { get; init; } = null!;

    /// <summary>
    /// List of inventory updates for the given hotel
    /// </summary>
    public List<Inventory> Inventories { get; init; } = null!;
}
