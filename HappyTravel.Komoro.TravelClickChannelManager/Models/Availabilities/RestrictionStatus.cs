using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;

/// <summary>
/// Contains restriction details
/// </summary>
public record RestrictionStatus
{
    /// <summary>
    /// Restriction type. "Master" and "Arrival" are supported. If set, then @Status is required.
    /// </summary>
    [XmlAttribute]
    public string? Restriction { get; init; }

    /// <summary>
    /// Restriction status. Required when @Restriction is set. Can either be "Open" or "Close"
    /// </summary>
    [XmlAttribute]
    public string? Status { get; init; }

    /// <summary>
    /// Cutoff/advanced purchase period. Is is an XML duration data type, but this can only currently be specified in days. For instance, to set 
    /// a booking offset of 7 days, the value must be "P7D"
    /// </summary>
    [XmlAttribute]
    public string? MinAdvancedBookingOffset { get; init; }
}
