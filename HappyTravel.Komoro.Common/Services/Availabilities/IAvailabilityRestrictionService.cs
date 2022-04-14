using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.Common.Services.Availabilities;

public interface IAvailabilityRestrictionService
{
    Task<List<AvailabilityRestriction>> Get(int supplierId, string propertyCode);
    Task Update(int supplierId, List<AvailabilityRestriction> availabilityRestrictions);
}
