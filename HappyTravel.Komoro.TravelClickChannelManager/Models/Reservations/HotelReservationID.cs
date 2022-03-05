using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Hotel reservation ID
/// </summary>
public record HotelReservationID
{
    /// <summary>
    /// Reservation ID type. Currently only "13" is supported.
    /// </summary>
    [XmlAttribute]
    public string ResID_Type { get; init; } = "13";

    /// <summary>
    /// Reservation identifier
    /// </summary>
    [XmlAttribute]
    public string ResID_Value { get; init; } = string.Empty;
}
