using HappyTravel.KomoroContracts;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.Common.Services.Availabilities;

public interface IAvailabilityRestrictionService
{
    Task<(List<AvailabilityRestriction>, List<ErrorDetails>)> Get(AvailabilityRestrictionRequest request);
    Task Update(int supplierId, List<AvailabilityRestriction> availabilityRestrictions);
}
