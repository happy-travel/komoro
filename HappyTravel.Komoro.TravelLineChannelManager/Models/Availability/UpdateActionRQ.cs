namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Availability;

/// <summary>
/// A request is sent to change the availability of a room category, its price, or to close sales in a channel
/// </summary>
internal record UpdateActionRQ : BaseRequest
{
    /// <summary>
    /// Request content
    /// </summary>
    public UpdateActionRQData Data { get; init; } = null!;
}
