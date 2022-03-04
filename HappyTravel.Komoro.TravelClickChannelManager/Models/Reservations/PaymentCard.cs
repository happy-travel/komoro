using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Credit card guarantee information
/// </summary>
public record PaymentCard
{
    /// <summary>
    /// Credit card expiration date in MMYY format
    /// </summary>
    [XmlAttribute]
    public string ExpireDate { get; init; } = string.Empty;

    /// <summary>
    /// Card type
    /// </summary>
    public CardType CardType { get; init; } = new();

    /// <summary>
    /// Card number
    /// </summary>
    public CardNumber CardNumber { get; init; } = new();

    /// <summary>
    /// Name as shown on credit card
    /// </summary>
    public string CardHolderName { get; init; } = string.Empty;

    /// <summary>
    /// Billing address
    /// </summary>
    public Address? Address { get; init; } = new();
}
