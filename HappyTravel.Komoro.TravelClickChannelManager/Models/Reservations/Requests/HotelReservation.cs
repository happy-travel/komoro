using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Requests;

/// <summary>
/// Hotel reservation
/// </summary>
public record HotelReservation
{
    /// <summary>
    /// Reservation status. Must be one of the following: Commit, Cancel, Modify
    /// </summary>
    [XmlAttribute]
    public string ResStatus { get; init; } = string.Empty;

    /// <summary>
    /// Timestamp indicating when this reservation was created
    /// </summary>
    [XmlAttribute]
    public DateTime CreateDateTime { get; init; }

    /// <summary>
    /// Timestamp indicating when this reservation was last modified
    /// </summary>
    [XmlAttribute]
    public DateTime LastModifyDateTime { get; init; }

    /// <summary>
    /// Reservation global information
    /// </summary>
    public ResGlobalInfo ResGlobalInfo { get; init; } = new();

    /// <summary>
    /// Optional list of guests
    /// </summary>
    public List<ResGuest>? ResGuests { get; init; }

    /// <summary>
    /// Room stays
    /// </summary>
    public List<RoomStay> RoomStays { get; init; } = null!;
}
