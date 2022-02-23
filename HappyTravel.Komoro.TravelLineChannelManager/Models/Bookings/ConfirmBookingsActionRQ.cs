namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// 
/// </summary>
internal record ConfirmBookingsActionRQ : BaseRequest
{
    /// <summary>
    /// 
    /// </summary>
    public ConfirmBookingsActionRQData Data { get; init; } = null!;
}
