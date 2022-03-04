using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;

/// <summary>
/// Specifies date range and product to which the restrictions should be applied
/// </summary>
public record StatusApplicationControl
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

    /// <summary>
    /// Room type ID of this product
    /// </summary>
    [XmlAttribute]
    public string InvTypeCode { get; init; } = string.Empty;

    /// <summary>
    /// Rate plan ID of this product
    /// </summary>
    [XmlAttribute]
    public string RatePlanCode { get; init; } = string.Empty;
}
