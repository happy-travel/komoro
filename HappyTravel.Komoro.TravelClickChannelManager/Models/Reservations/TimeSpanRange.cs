using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Date range for the stay
/// </summary>
[XmlRoot(ElementName = "TimeSpan")]
public record TimeSpanRange
{
    /// <summary>
    /// Check in date of this stay
    /// </summary>
    [XmlAttribute(DataType = "date")]
    public DateTime Start { get; init; }

    /// <summary>
    /// Check out date of this stay
    /// </summary>
    [XmlAttribute(DataType = "date")]
    public DateTime End { get; init; }
}
