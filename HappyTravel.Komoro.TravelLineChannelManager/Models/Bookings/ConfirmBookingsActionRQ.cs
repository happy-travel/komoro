namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Bookings are made in your system from a free quota, are transferred to the accommodation facility automatically and do not require additional 
/// confirmation from the hotel. The purpose of this function is to provide confirmation of the fact that the technical delivery of the reservation 
/// from your system to the channel manager was successful.
/// If the channel manager does NOT confirm receipt of the reservation with a response containing "success": true, then the channel must store and return 
/// this reservation on its side in subsequent requests until the channel manager acknowledges its receipt.
/// The channel manager confirms the successful acceptance of bookings with the GetBookingsActionRS function.
/// </summary>
internal record ConfirmBookingsActionRQ : BaseRequest
{
    /// <summary>
    /// Request content
    /// </summary>
    public ConfirmBookingsActionRQData Data { get; init; } = null!;
}
