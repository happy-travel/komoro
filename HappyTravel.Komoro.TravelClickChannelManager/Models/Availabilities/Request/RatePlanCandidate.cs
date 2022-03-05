using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Rate plan candidate
/// </summary>
public record RatePlanCandidate
{
    /// <summary>
    /// Rate plan identifier
    /// </summary>
    [XmlAttribute]
    public string RatePlanCode { get; init; } = string.Empty;
}
