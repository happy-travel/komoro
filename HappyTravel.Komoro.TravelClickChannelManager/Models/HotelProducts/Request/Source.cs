namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;

/// <summary>
/// Source
/// </summary>
public class Source
{
    /// <summary>
    /// Booking channel
    /// </summary>
    public BookingChannel BookingChannel { get; set; } = new();
}
