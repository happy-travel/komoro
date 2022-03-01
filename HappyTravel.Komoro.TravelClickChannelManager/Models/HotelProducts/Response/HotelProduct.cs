namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

public class HotelProduct
{
    /// <summary>
    /// List of rate plans
    /// </summary>
    public List<RatePlan> RatePlans { get; set; } = null!;

    /// <summary>
    /// List of room types
    /// </summary>
    public List<RoomType> RoomTypes { get; set; } = null!;
}
