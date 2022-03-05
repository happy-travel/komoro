namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Reservation (order, application)
/// </summary>
internal record Booking
{
    /// <summary>
    /// The number (identifier) of the reservation assigned by the channel. The number must be unique for each booking
    /// </summary>
    public string Number { get; init; } = string.Empty;

    /// <summary>
    /// Date and time of booking creation (UTC+0)
    /// </summary>
    public DateTimeOffset Created { get; init; }

    /// <summary>
    /// Check-in time of the guest on the day of arrival (according to hotel time)
    /// </summary>
    public TimeSpan ArrivalTime { get; init; }

    /// <summary>
    /// Check-out time of the guest on the day of departure (according to hotel time)
    /// </summary>
    public TimeSpan DepartureTime { get; init; }

    /// <summary>
    /// Booking status. Can take one of the set values:
    /// • new – new booking.
    /// • modified – modification of an existing armor.
    /// • cancelled – cancellation of an existing booking.
    /// If the channel uses more booking statuses, it is necessary to bring the channel statuses to those of the channel manager by deleting the excess.
    /// </summary>
    public BookingStatuses Status { get; init; }

    /// <summary>
    /// Channel host ID. This channel ID is reported to the host and the channel manager during the connection phase of the host.
    /// </summary>
    public string HotelId { get; init; } = string.Empty;

    /// <summary>
    /// Currency code
    /// </summary>
    public string CurrencyCode { get; init; } = string.Empty;

    /// <summary>
    /// Payment method. One of many:
    /// • CREDIT - credit card
    /// • CASH - cash on arrival
    /// • PREPAY - prepaid reservation
    /// </summary>
    public PaymentMethods PaymentMethod { get; init; }

    /// <summary>
    /// Brief comment about the payment method. Up to 70 characters including spaces
    /// </summary>
    public string PaymentMethodComment { get; init; } = string.Empty;

    /// <summary>
    /// An array of room categories. If two rooms of the same category are booked, then the array must contain two elements
    /// </summary>
    public List<RoomStay> RoomStays { get; init; } = null!;

    /// <summary>
    /// Details of the person booking the room. If your system does not have such a concept, the fields can be filled with the data of the first guest
    /// </summary>
    public Customer Customer { get; init; } = null!;
}
