using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Guest count
/// </summary>
public record GuestCount
{
    /// <summary>
    /// Number of guests
    /// </summary>
    [XmlAttribute]
    public int Count { get; init; }

    /// <summary>
    /// Age code of these guests. See AQC code types
    /// </summary>
    [XmlAttribute]
    public int AgeQualifyingCode { get; init; }
}
