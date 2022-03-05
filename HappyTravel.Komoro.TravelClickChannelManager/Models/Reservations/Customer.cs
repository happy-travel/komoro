namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Customer
/// </summary>
public record Customer
{
    /// <summary>
    /// Person name
    /// </summary>
    public PersonName PersonName { get; init; } = new();

    /// <summary>
    /// Guest phone number
    /// </summary>
    public string? Telephone { get; init; }

    /// <summary>
    /// Guest email address
    /// </summary>
    public string? Email { get; init; }

    /// <summary>
    /// Guest mailing address
    /// </summary>
    public Address? Address { get; init; }
}
