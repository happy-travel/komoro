namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

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
