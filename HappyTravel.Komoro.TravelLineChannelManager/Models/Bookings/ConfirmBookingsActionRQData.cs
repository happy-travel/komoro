namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// ConfirmBookingsActionRQ request content
/// </summary>
internal record ConfirmBookingsActionRQData
{
    public List<ConfirmBooking> ConfirmBookings { get; init; } = null!;

}
