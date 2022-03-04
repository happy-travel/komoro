namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Requests;

/// <summary>
/// Reservation global information
/// </summary>
public record ResGlobalInfo
{
    /// <summary>
    /// List of hotel reservation ID
    /// </summary>
    public List<HotelReservationID> HotelReservationIDs { get; init; } = null!;
}
