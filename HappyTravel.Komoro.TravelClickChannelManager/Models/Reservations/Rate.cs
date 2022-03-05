using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Rate details. For each RoomStay, the Rate date ranges must be contiguous, they must not overlap ambiguously, and the combination of all Rate 
/// date ranges must account for the entire RoomStay's TimeSpan.
/// </summary>
public record Rate
{
    /// <summary>
    /// Can be one of the following values: Per night, Per stay
    /// </summary>
    [XmlAttribute]
    public string RoomPricingType { get; init; } = string.Empty;

    /// <summary>
    /// Effective (start) date of pricing date range (inclusive)
    /// </summary>
    [XmlAttribute]
    public DateTime EffectiveDate { get; init; }

    /// <summary>
    /// Expire (end) date of pricing date range (exclusive)
    /// </summary>
    [XmlAttribute]
    public DateTime ExpireDate { get; init; }

    /// <summary>
    /// Base rate
    /// </summary>
    public Base Base { get; init; } = new();
}
