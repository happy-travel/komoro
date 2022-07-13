using CSharpFunctionalExtensions;
using HappyTravel.EdoContracts.Accommodations;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public interface IWideAvailabilitySearchService
{
    Task<Result<Availability>> Get(string supplierCode, AvailabilityRequest request, CancellationToken cancellationToken);
}
