namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

public record HotelProduct
{
    /// <summary>
    /// List of rate plans
    /// </summary>
    public List<RatePlan> RatePlans { get; init; } = null!;

    /// <summary>
    /// List of room types
    /// </summary>
    public List<RoomType> RoomTypes { get; init; } = null!;
}
