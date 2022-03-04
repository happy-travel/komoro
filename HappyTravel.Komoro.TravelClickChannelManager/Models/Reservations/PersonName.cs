namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Person name
/// </summary>
public record PersonName
{
    /// <summary>
    /// Guest given name
    /// </summary>
    public string GivenName = string.Empty;

    /// <summary>
    /// Guest surname
    /// </summary>
    public string Surname = string.Empty;
}
