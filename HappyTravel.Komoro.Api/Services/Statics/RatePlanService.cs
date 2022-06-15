namespace HappyTravel.Komoro.Api.Services.Statics;

public class RatePlanService : IRatePlanService
{
    public bool IsExist(string ratePlanCode)
        => ratePlanCodes.Any(rpc => rpc == ratePlanCode);


    private readonly List<string> ratePlanCodes = new()
    {
        "SRO",  // StandardRO
        "SBB",  // StandardBB
        "SSRO", // StaySaveRO
        "SSBB", // StaySaveBB
        "EBRO", // EarlyBirdRO
        "EBBB", // EarlyBirdBB
        "SDRO", // SpecialDealRO
        "SDBB"  // SpecialDealBB
    };
}
