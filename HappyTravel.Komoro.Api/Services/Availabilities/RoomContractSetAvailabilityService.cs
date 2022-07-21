using CSharpFunctionalExtensions;
using HappyTravel.EdoContracts.Accommodations;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public class RoomContractSetAvailabilityService : IRoomContractSetAvailabilityService
{
    public async Task<Result<RoomContractSetAvailability?>> Get(string supplierCode, string availabilityId, Guid roomContractSetId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
