using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Requests;

/// <summary>
/// Creating and Modifying Reservations
/// Request is initiated by OTA Partner
/// While a commit creates a new reservation and a modification updates an existing reservation, the message content for these two types of events
/// are basically the same.The primary difference is that a commit will feature a HotelReservation/@ResStatus value of "Commit" while a modification
/// contains "Modify" instead.Both types of reservation events must contain the full state of the reservation.In other words, a modification cannot
/// be simply the delta between the previous state and the new state, but rather it must contain the new state in its entirety.
/// </summary>
[XmlRoot(ElementName = "OTA_HotelResNotifRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelResNotifRQ : BaseRequest
{
    /// <summary>
    /// Point of Sale. TravelClick will only send this information if specifically requested by OTA partner.
    /// </summary>
    [XmlElement(ElementName = "POS")]
    public Pos Pos { get; init; } = null!;

    /// <summary>
    /// List of hotel reservations
    /// </summary>
    public List<HotelReservation> HotelReservations { get; init; } = null!;
}
