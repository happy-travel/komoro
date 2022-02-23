namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Get bookings action request content
/// </summary>
internal class GetBookingsActionRqData
{
    /// <summary>
    /// Channel host ID. This channel ID informs the host and the channel manager during the connection phase of the host.
    /// Optional parameter: if the parameter is omitted, then all unconfirmed bookings are returned for all accommodations linked in the channel 
    /// to the channel manager.Used to retrieve unconfirmed bookings for a specific accommodation.
    /// </summary>
    public string? HotelId { get; init; }

    /// <summary>
    /// The date and time of the booking, from which you need to give the reservation from the queue. Time (UTC+0).
    /// Optional parameter: if the parameter is omitted, then all unconfirmed reservations are returned.
    /// A request specifying startTime should return bookings that have been "affected" (created/modified/cancelled) in any way since the specified date.
    /// Including previously confirmed ones.The booking status must be final - the one that is set in your system at the time of the request. 
    /// The startTime parameter will be used for emergency cases: if there is no 100% certainty that the booking data is synchronized with your system.
    /// </summary>
    public DateTimeOffset? StartTime { get; init; }

    /// <summary>
    /// The number (identifier) of the reservation assigned by the channel.
    /// Optional parameter. For a request specifying number, it is necessary to return a booking with the specified number in the current state 
    /// at the time of the request. The number parameter will be used for emergency cases: if there is no 100% certainty that the data for a specific 
    /// booking is synchronized with your system.
    /// </summary>
    public string? Number { get; init; }
}
