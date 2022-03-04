namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Hotel availability request 
/// </summary>
public record HotelAvailRequest
{
    /// <summary>
    /// Contains the date range that the returned availability data must cover
    /// </summary>
    public DateRange DateRange { get; init; } = new();

    /// <summary>
    /// Rate plan candidates
    /// </summary>
    public List<RatePlanCandidate> RatePlanCandidates { get; init; } = null!;

    /// <summary>
    /// Room type candidates
    /// </summary>
    public List<RoomTypeCandidate> RoomTypeCandidates { get; init; } = null!;

    /// <summary>
    /// Hotel reference
    /// </summary>
    public HotelRef HotelRef { get; init; } = new();
}
