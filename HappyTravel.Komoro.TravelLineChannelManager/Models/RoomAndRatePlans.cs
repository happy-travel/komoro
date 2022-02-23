namespace HappyTravel.Komoro.TravelLineChannelManager.Models;

/// <summary>
/// Room category and corresponding tariff plans
/// </summary>
internal record RoomAndRatePlans
{
    /// <summary>
    /// Room category identifier
    /// </summary>
    public string RoomTypeId { get; init; } = string.Empty;

    /// <summary>
    /// Name of room category
    /// </summary>
    public string RoomName { get; init; } = string.Empty;

    /// <summary>
    /// An array of rate plans for which the number is sold. If the channel does not support the sale of numbers under several rate plans, 
    /// then you still need to return one rate plan. For example, it could be "ratePlanName": "Basic" with "ratePlanId": "1" for each hotel and category.
    /// </summary>
    public List<RatePlan> RatePlans { get; init; } = null!;

    /// <summary>
    /// An array of types of accommodation in the room (single, double, etc.). The array lists all supported placements. If the channel does not support
    /// different placements in the rooms, then the block may be missing.
    /// </summary>
    public List<Occupancy> Occupancies { get; init; } = null!;
}
