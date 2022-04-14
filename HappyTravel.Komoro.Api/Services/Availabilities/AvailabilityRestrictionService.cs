using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;
using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.Common.Services.Statics;
using HappyTravel.Komoro.Data;
using HappyTravel.KomoroContracts.Availabilities;
using Microsoft.EntityFrameworkCore;
using DataModels = HappyTravel.Komoro.Data.Models.Availabilities;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public class AvailabilityRestrictionService : IAvailabilityRestrictionService
{
    public AvailabilityRestrictionService(KomoroContext komoroContext, IDateTimeOffsetProvider dateTimeOffsetProvider, IPropertyService propertyService, IRoomTypeService roomTypeService)
    {
        _komoroContext = komoroContext;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _propertyService = propertyService;
        _roomTypeService = roomTypeService;
    }


    public async Task<List<AvailabilityRestriction>> Get(int supplierId, string propertyCode)
    {
        return await _komoroContext.AvailabilityRestrictions
            .Include(ar => ar.Property)
            .Include(ar => ar.RoomType)
            .Where(ar => ar.Property.Code == propertyCode)
            .Select(ar => ar.ToApiAvailabilityRestriction())
            .ToListAsync();
    }


    public async Task Update(int supplierId, List<AvailabilityRestriction> availabilityRestrictions)
    {
        foreach (var restriction in availabilityRestrictions)
        {
            var existingRestrictions = await _komoroContext.AvailabilityRestrictions
                .Include(ar => ar.Property)
                .Include(ar => ar.RoomType)
                .Where(ar => ar.Property.Code == restriction.PropertyCode
                    && ar.StartDate == restriction.StartDate 
                    && ar.EndDate == restriction.EndDate 
                    && ar.RoomType.Code == restriction.RoomTypeCode
                    && ar.RatePlanCode == restriction.RatePlanCode)
                .ToListAsync();
            var utcNow = _dateTimeOffsetProvider.UtcNow();

            if (restriction.RestrictionStatusDetails is not null)
                await AddOrUpdateRestrictionStatus(restriction, existingRestrictions);
            else if (restriction.StayDurationDetails is not null)
                await AddOrUpdateLengthOfStay(restriction, existingRestrictions);

            await _komoroContext.SaveChangesAsync();
        }
        
        
        async Task AddOrUpdateRestrictionStatus(AvailabilityRestriction restriction, List<DataModels.AvailabilityRestriction> existingRestrictions)
        {
            var existingRestriction = existingRestrictions
                .SingleOrDefault(r => r.RestrictionStatusDetails.Restriction == restriction.RestrictionStatusDetails.Restriction);
            var utcNow = _dateTimeOffsetProvider.UtcNow();
            if (existingRestriction is null)
            {
                var propertyId = await _propertyService.GetId(supplierId, restriction.PropertyCode);    // Need to add check propertyId !=0
                var roomTypeId = await _roomTypeService.GetId(restriction.RoomTypeCode);                // Need to add check roomTypeId !=0
                var newRestriction = new DataModels.AvailabilityRestriction
                {
                    StartDate = restriction.StartDate,
                    EndDate = restriction.EndDate,
                    PropertyId = propertyId,
                    RoomTypeId = roomTypeId,
                    RatePlanCode = restriction.RatePlanCode,
                    RestrictionStatusDetails = restriction.RestrictionStatusDetails,
                    StayDurationDetails = null,
                    Created = utcNow,
                    Modified = utcNow
                };
                _komoroContext.AvailabilityRestrictions.Add(newRestriction);
            }
            else
            {
                existingRestriction.RestrictionStatusDetails = restriction.RestrictionStatusDetails;
                existingRestriction.Modified = utcNow;
                _komoroContext.AvailabilityRestrictions.Update(existingRestriction);
            }
        }


        async Task AddOrUpdateLengthOfStay(AvailabilityRestriction restriction, List<DataModels.AvailabilityRestriction> existingRestrictions)
        {
            var existingRestriction = existingRestrictions
                .SingleOrDefault(r => r.StayDurationDetails is not null);
            var utcNow = _dateTimeOffsetProvider.UtcNow();
            if (existingRestriction is null)
            {
                var propertyId = await _propertyService.GetId(supplierId, restriction.PropertyCode);    // Need to add check propertyId !=0
                var roomTypeId = await _roomTypeService.GetId(restriction.RoomTypeCode);                // Need to add check roomTypeId !=0
                var newRestriction = new DataModels.AvailabilityRestriction
                {
                    StartDate = restriction.StartDate,
                    EndDate = restriction.EndDate,
                    PropertyId = propertyId,
                    RoomTypeId = roomTypeId,
                    RatePlanCode = restriction.RatePlanCode,
                    RestrictionStatusDetails = null,
                    StayDurationDetails = restriction.StayDurationDetails,
                    Created = utcNow,
                    Modified = utcNow
                };
                _komoroContext.AvailabilityRestrictions.Add(newRestriction);
            }
            else
            {
                existingRestriction.RestrictionStatusDetails = restriction.RestrictionStatusDetails;
                existingRestriction.Modified = utcNow;
                _komoroContext.AvailabilityRestrictions.Update(existingRestriction);
            }
        }
    }


    private readonly KomoroContext _komoroContext;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IPropertyService _propertyService;
    private readonly IRoomTypeService _roomTypeService;
}
