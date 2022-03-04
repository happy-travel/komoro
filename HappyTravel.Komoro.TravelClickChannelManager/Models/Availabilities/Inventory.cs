namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;

/// <summary>
/// Inventory details
/// </summary>
public record Inventory
{
    /// <summary>
    /// Specifies date range and product to which the inventory should be applied
    /// </summary>
    public StatusApplicationControl StatusApplicationControl { get; init; } = null!;

    /// <summary>
    /// List of inventory counts. Currently only a single InvCount element is supported for inventory update requests
    /// </summary>
    public List<InvCount> InvCounts { get; init; } = null!;
}
