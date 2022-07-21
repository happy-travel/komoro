using CSharpFunctionalExtensions;
using HappyTravel.EdoContracts.Accommodations;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public interface IRoomContractSetAvailabilityService
{
    Task<Result<RoomContractSetAvailability?>> Get(string supplierCode, string availabilityId, Guid roomContractSetId, CancellationToken cancellationToken);
}
