namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Requests;

/// <summary>
/// Basic property information
/// </summary>
public record BasicPropertyInfo
{
    /// <summary>
    /// Hotel identifier
    /// </summary>
    public string HotelCode { get; init; } = string.Empty;
}
