using CSharpFunctionalExtensions;
using HappyTravel.EdoContracts.Accommodations;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public interface IDeadlineService
{
    Task<Result<Deadline>> Get(string supplierCode, string availabilityId, Guid roomContractSetId, CancellationToken cancellationToken);
}
