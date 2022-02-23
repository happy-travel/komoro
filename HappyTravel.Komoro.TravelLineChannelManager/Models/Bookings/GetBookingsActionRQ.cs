namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// A request is sent to a channel to retrieve the reservations stored in the channel's queue
/// </summary>
internal record GetBookingsActionRQ : BaseRequest
{
    /// <summary>
    /// Request content
    /// </summary>
    public BookingsActionRqData Data { get; init; } = null!;
}
