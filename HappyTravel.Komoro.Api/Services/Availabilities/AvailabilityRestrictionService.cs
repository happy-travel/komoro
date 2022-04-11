using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;
using HappyTravel.Komoro.Data;
using HappyTravel.KomoroContracts.Availabilities;
using Microsoft.EntityFrameworkCore;

namespace HappyTravel.Komoro.Api.Services.Availabilities
{
    public class AvailabilityRestrictionService : IAvailabilityRestrictionService
    {
        public AvailabilityRestrictionService(KomoroContext komoroContext)
        {
            _komoroContext = komoroContext;
        }


        public async Task<List<AvailabilityRestriction>> Get(int propertyId)
        {
            return await _komoroContext.AvailabilityRestrictions.Where(ar => ar.PropertyId == propertyId)
                .Select(ar => ar.ToApiAvailabilityRestriction())
                .ToListAsync();
        }


        public async Task Update(List<AvailabilityRestriction> availabilityRestrictions)
        {

        }


        private readonly KomoroContext _komoroContext;
    }
}
