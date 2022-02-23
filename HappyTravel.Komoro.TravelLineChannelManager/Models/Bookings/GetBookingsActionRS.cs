namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Response to a GetBookingsActionRQ request. Contains a list of bookings according to the parameters of the "data" object from GetBookingsActionRQ
/// </summary>
internal record GetBookingsActionRS : BaseResponse
{
    /// <summary>
    /// Response content
    /// </summary>
    public BookingsActionRsData Data { get; init; } = null!;

    /// <summary>
    /// Warnings
    /// </summary>
    public List<string> Warnings { get; init; } = null!;
    
    /// <summary>
    /// Errors
    /// </summary>
    public List<string> Errors { get; init; } = null!;
}
