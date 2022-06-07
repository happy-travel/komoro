using HappyTravel.KomoroContracts;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.Common.Services.Availabilities;

public interface IRateService
{
    Task<(Rate, List<ErrorDetails>)> Get(RateRequest request);
    Task<List<ErrorDetails>> Update(Rate rate);
}
