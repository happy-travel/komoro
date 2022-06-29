using HappyTravel.KomoroContracts.Enums;

namespace HappyTravel.Komoro.Api.Services.Statics;

public class RatePlanService : IRatePlanService
{
    public List<string> Get()
    {
        var ratePlans = (RatePlans[])Enum.GetValues(typeof(RatePlans));

        return ratePlans.Select(rp => rp.ToString()).ToList();
    }


    public bool IsExist(string ratePlanCode)
    {
        var ratePlans = (RatePlans[])Enum.GetValues(typeof(RatePlans));

        return ratePlans.Select(rp => rp.ToString()).Any(rpc => rpc == ratePlanCode);
    }
}
