using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Contains the date range that the returned availability data must cover
/// </summary>
public record DateRange
{
    /// <summary>
    /// Start date in YYYY-MM-DD format
    /// </summary>
    [XmlAttribute(DataType = "date")]
    public DateTime Start { get; init; }

    /// <summary>
    /// End date (inclusive) in YYYY-MM-DD format
    /// </summary>
    [XmlAttribute(DataType = "date")]
    public DateTime End { get; init; }
}
