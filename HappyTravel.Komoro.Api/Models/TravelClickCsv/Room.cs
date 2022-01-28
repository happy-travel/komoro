namespace HappyTravel.Komoro.Api.Models.TravelClickCsv;

public record Room
{
    public string RoomType { get; init; } = null!;
    public string StandardMealPlan { get; init; } = null!;
    public string StandardOccupancy { get; init; } = null!;
    public string MaximumOccupancy { get; init; } = null!;
    public string ExtraAdultSupplement { get; init; } = null!;
    public string ChildSupplement { get; init; } = null!;
    public string InfantSupplement { get; init; } = null!;
    public string StandardRO { get; init; } = null!;
    public string StandardBB { get; init; } = null!;
    public string StaySaveRO { get; init; } = null!;
    public string StaySaveBB { get; init; } = null!;
    public string EarlyBirdRO { get; init; } = null!;
    public string EarlyBirdBB { get; init; } = null!;
    public string SpecialDealRO { get; init; } = null!;
    public string SpecialDealBB { get; init; } = null!;
}
