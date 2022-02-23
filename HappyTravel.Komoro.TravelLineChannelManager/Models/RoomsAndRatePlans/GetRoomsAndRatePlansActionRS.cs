namespace HappyTravel.Komoro.TravelLineChannelManager.Models.RoomsAndRatePlans;

/// <summary>
/// Response to a GetRoomsAndRatePlansActionRQ request. The response contains identifiers and names of room categories, as well as tariff plans 
/// for which this category of numbers is sold.
/// </summary>
internal record GetRoomsAndRatePlansActionRS : BaseResponse
{
    /// <summary>
    /// Response content
    /// </summary>
    public RoomsAndRatePlansActionRsData Data { get; init; } = null!;
}
