using CSharpFunctionalExtensions;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public interface IAccommodationAvailabilityService
{
    Task<Result<EdoContracts.Accommodations.AccommodationAvailability>> Get(string supplierCode, string availabilityId, string accommodationId, CancellationToken cancellationToken);
}
