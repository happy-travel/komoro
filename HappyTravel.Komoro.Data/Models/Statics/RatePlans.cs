namespace HappyTravel.Komoro.Data.Models.Statics;

[Flags]
public enum RatePlans
{
    None = 0,
    StandardRO = 1,
    StandardBB = 2,
    StaySaveRO = 4,
    StaySaveBB = 8,
    EarlyBirdRO = 16,
    EarlyBirdBB = 32,
    SpecialDealRO = 64,
    SpecialDealBB = 128
}
