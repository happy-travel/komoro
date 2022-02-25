namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Response to a GetBookingsActionRQ request. Contains a list of bookings according to the parameters of the "data" object from GetBookingsActionRQ
/// </summary>
internal record GetBookingsActionRS : BaseResponse
{
    /// <summary>
    /// Response content
    /// </summary>
    public GetBookingsActionRsData Data { get; init; } = null!;
}
