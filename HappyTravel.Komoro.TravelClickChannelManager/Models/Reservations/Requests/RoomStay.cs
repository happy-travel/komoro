using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Requests;

/// <summary>
/// Room stay
/// </summary>
public record RoomStay
{
    /// <summary>
    /// Index number that can be used as a reference to this RoomStay for partial modification or cancellation. Once this number is established for 
    /// the given RoomStay by the inital Commit, it must remain consistent even as modifications or cancellations are applied to the reservation 
    /// (in other words, the RoomStay nodes must not be reindexed as changes are made to the reservation).
    /// </summary>
    [XmlAttribute]
    public int IndexNumber { get; init; }

    /// <summary>
    /// Promotion code. This is simply informational and will typically be delivered to the hotel as an additional comment on the reservation.
    /// </summary>
    [XmlAttribute]
    public string? PromotionCode { get; init; }

    /// <summary>
    /// Basic property information
    /// </summary>
    public BasicPropertyInfo BasicPropertyInfo { get; init; } = new();

    /// <summary>
    /// Date range for the stay
    /// </summary>
    public TimeSpanRange TimeSpan { get; init; } = new();


    /// <summary>
    /// List of comments associated with this guest
    /// </summary>
    //public List<RoomRate>? RoomRates { get; init; }

    /// <summary>
    /// Guest RPH associated with this RoomStay
    /// </summary>
    public int ResGuestRPHs { get; init; }
}
