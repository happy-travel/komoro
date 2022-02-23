namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Response content
/// </summary>
internal record GetBookingsActionRsData
{
    /// <summary>
    /// An array of reservations (orders, applications). If there are no reservations for the period of time, then the array is returned empty. 
    /// If there are reservations, then the array contains all reservations not confirmed by the channel manager
    /// </summary>
    public List<Booking> Bookings { get; init; } = null!;
}
