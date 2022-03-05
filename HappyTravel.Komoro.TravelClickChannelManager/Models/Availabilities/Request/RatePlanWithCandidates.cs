using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Rate plan
/// </summary>
[XmlRoot(ElementName = "RatePlan")]
public record RatePlanWithCandidates
{
    /// <summary>
    /// Contains the date range that the returned rate data must cover
    /// </summary>
    public DateRange DateRange { get; init; } = new();

    /// <summary>
    /// List of rate plan candidates
    /// </summary>
    public List<RatePlanCandidate> RatePlanCandidates { get; init; } = null!;

    /// <summary>
    /// Hotel reference
    /// </summary>    
    public HotelRef HotelRef { get; init; } = new();
}
