using CSharpFunctionalExtensions;
using HappyTravel.EdoContracts.Accommodations;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public class AccommodationAvailabilityService : IAccommodationAvailabilityService
{
    public async Task<Result<AccommodationAvailability>> Get(string supplierCode, string availabilityId, string accommodationId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
