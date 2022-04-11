using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public interface IAvailabilityRestrictionService
{
    Task<List<AvailabilityRestriction>> Get(int propertyId);
    Task Update(List<AvailabilityRestriction> availabilityRestrictions);
}
