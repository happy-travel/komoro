using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.KomoroContracts;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public class RateService : IRateService
{
    public async Task<(Rate, List<ErrorDetails>)> Get(RateRequest request)
    {
        throw new NotImplementedException();
    }


    public async Task<List<ErrorDetails>> Update(Rate rate)
    {
        throw new NotImplementedException();
    }
}
