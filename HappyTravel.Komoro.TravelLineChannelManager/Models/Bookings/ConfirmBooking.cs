namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Confirmed booking details
/// </summary>
internal record ConfirmBooking
{
    /// <summary>
    /// Reservation number assigned by the channel
    /// </summary>
    public string Number { get; init; } = string.Empty;

    /// <summary>
    /// The technical number of the reservation in the channel manager system. This number is internal and is not shown to the specialists of the 
    /// accommodation facility. It is designed to search for reservations when resolving a disputable situation
    /// </summary>
    public string ExternalNumber { get; init; } = string.Empty;

    /// <summary>
    /// Booking status. Can take one of the set values:
    /// • new – new booking.
    /// • modified – modification of an existing armor.
    /// • cancelled – cancellation of an existing booking.
    /// This status is an "echo" of your status at the time the booking was saved in the channel manager. For example, you gave away a booking with
    /// the new status using GetBookingsAction. We will confirm in the confirm-bookings message that the new booking has been saved in the channel manager.
    /// </summary>
    public BookingStatuses Status { get; init; }
}
