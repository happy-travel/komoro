namespace HappyTravel.Komoro.TravelLineChannelManager.Models.RoomsAndRatePlans;

/// <summary>
/// The request will be sent to the channel to get rate plans and room categories from the channel
/// </summary>
internal record GetRoomsAndRatePlansActionRQ : BaseRequest
{
    /// <summary>
    /// Request content
    /// </summary>
    public RoomsAndRatePlansActionRqData Data { get; init; } = null!;
}
