using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// List of guests associated with this reservation. At least one ResGuest is expected per RoomStay in a reservation.
/// </summary>
public record ResGuest
{
    /// <summary>
    /// Index by which this guest can be referenced within the RoomStay elements
    /// </summary>
    [XmlAttribute]
    public string? ResGuestRPH { get; init; }

    /// <summary>
    /// Profiles
    /// </summary>
    public Profiles Profiles { get; init; } = new();

    /// <summary>
    /// List of special requests for this guest
    /// </summary>
    public List<SpecialRequest>? SpecialRequests { get; init; }

    /// <summary>
    /// List of comments associated with this guest
    /// </summary>
    public List<Comment>? Comments { get; init; }
}
