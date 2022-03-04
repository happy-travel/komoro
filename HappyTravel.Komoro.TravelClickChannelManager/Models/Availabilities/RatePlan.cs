using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;

/// <summary>
/// Rate plan and date range details
/// </summary>
public record RatePlan
{
    /// <summary>
    /// Rate plan identifier
    /// </summary>
    [XmlAttribute]
    public string RatePlanCode { get; init; } = string.Empty;
    
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

    /// <summary>
    /// Rates
    /// </summary>
    public List<Rate> Rates { get; init; } = null!;
}
