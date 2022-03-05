namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// List of accepted guaratees
/// </summary>
public record GuaranteesAccepted
{
    /// <summary>
    /// Credit card guarantee information
    /// </summary>
    public PaymentCard PaymentCard { get; init; } = new();
}
