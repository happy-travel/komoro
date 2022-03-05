using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Room rate
/// </summary>
public record RoomRate
{
    /// <summary>
    /// Number of rooms booked with these stay details. Currently only a value of "1" is supported. Additional rooms must be specified by individual 
    /// RoomStay elements instead.
    /// </summary>
    [XmlAttribute]
    public int NumberOfUnits { get; init; }

    /// <summary>
    /// Room type identifier. This is expected to match across all RoomRate elements within the given RoomStay
    /// </summary>
    [XmlAttribute]
    public string RoomTypeCode { get; init; } = string.Empty;

    /// <summary>
    /// Rate plan identifier
    /// </summary>
    [XmlAttribute]
    public string RatePlanCode { get; init; } = string.Empty;

    /// <summary>
    /// List of rates
    /// </summary>
    public List<Rate> Rates { get; init; } = null!;
}
