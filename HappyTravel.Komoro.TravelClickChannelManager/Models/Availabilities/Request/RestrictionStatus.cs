using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Contains restriction details
/// </summary>
public record RestrictionStatus
{
    /// <summary>
    /// Restriction type. "Master" and "Arrival" are supported. If set, then @Status is required.
    /// </summary>
    [XmlAttribute]
    public string Restriction { get; init; } = string.Empty;

    /// <summary>
    /// Restriction status. Required when @Restriction is set. Can either be "Open" or "Close"
    /// </summary>
    [XmlAttribute]
    public string Status { get; init; } = string.Empty;
}
