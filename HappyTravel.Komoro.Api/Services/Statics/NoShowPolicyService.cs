using HappyTravel.KomoroContracts.Enums;

namespace HappyTravel.Komoro.Api.Services.Statics;

public class NoShowPolicyService : INoShowPolicyService
{
    public List<string> Get()
    {
        var ratePlans = (NoShowPolicies[])Enum.GetValues(typeof(NoShowPolicies));

        return ratePlans.Select(rp => rp.ToString()).ToList();
    }
}
