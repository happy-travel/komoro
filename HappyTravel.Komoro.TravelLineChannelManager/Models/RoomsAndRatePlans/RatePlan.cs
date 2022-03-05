namespace HappyTravel.Komoro.TravelLineChannelManager.Models.RoomsAndRatePlans;

/// <summary>
/// Rate plan
/// </summary>
internal record RatePlan
{
    /// <summary>
    /// Rate plan ID
    /// </summary>
    public string RatePlanId { get; init; } = string.Empty;
    
    /// <summary>
    /// Rate plan name
    /// </summary>
    public string RatePlanName { get; init; } = string.Empty;
}
