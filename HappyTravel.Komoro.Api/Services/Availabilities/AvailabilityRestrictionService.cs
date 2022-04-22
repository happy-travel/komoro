using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;
using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.Common.Services.Statics;
using HappyTravel.Komoro.Data;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure;
using HappyTravel.KomoroContracts;
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


    public async Task<(List<AvailabilityRestriction>, List<ErrorDetails>)> Get(AvailabilityRestrictionRequest request)
    {
        if (!await _propertyService.IsExist(request.SupplierId, request.PropertyCode))
            return (new(0), new List<ErrorDetails> 
                { new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidProperty, ObjectCode = request.PropertyCode } });

        var errorDetailsList = new List<ErrorDetails>();        
        foreach (var roomTypeCode in request.RoomTypeCodes)
        {
            if (!await _roomTypeService.IsExist(roomTypeCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRoomType, ObjectCode = roomTypeCode });
        }
        foreach (var ratePlanCode in request.RatePlanCodes)
        {
            if (!await _roomTypeService.IsExist(ratePlanCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRatePlan, ObjectCode = ratePlanCode });
        }
        if (errorDetailsList.Count > 0)
            return (new(0), errorDetailsList);

        var availabilityRestrictions = await _komoroContext.AvailabilityRestrictions
            .Include(ar => ar.Property)
            .Include(ar => ar.RoomType)
            .Where(ar => ar.Property.SupplierId == request.SupplierId
                && ar.Property.Code == request.PropertyCode 
                && request.RatePlanCodes.Contains(ar.RatePlanCode)
                && request.RoomTypeCodes.Contains(ar.RoomType.Code)
                && ((ar.StartDate <= request.StartDate && ar.EndDate >= request.EndDate) 
                    || (ar.StartDate >= request.StartDate && ar.EndDate <= request.EndDate)
                    || (ar.StartDate >= request.StartDate && ar.StartDate <= request.EndDate)
                    || (ar.EndDate >= request.StartDate && ar.EndDate <= request.EndDate)))
            .Select(ar => ar.ToApiAvailabilityRestriction())
            .ToListAsync();

        return (availabilityRestrictions, errorDetailsList);
    }


    public async Task<List<ErrorDetails>> Update(int supplierId, List<AvailabilityRestriction> availabilityRestrictions)
    {
        var propertyCode = availabilityRestrictions.First().PropertyCode;   // All availability offers are always requested from one property
        if (!await _propertyService.IsExist(supplierId, propertyCode))
            return (new List<ErrorDetails>
                { new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidProperty, ObjectCode = propertyCode } });

        var errorDetailsList = new List<ErrorDetails>();
        foreach (var availabilityRestriction in availabilityRestrictions)
        {
            if (!await _roomTypeService.IsExist(availabilityRestriction.RoomTypeCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRoomType, ObjectCode = availabilityRestriction.RoomTypeCode });
            
            if (!await _roomTypeService.IsExist(availabilityRestriction.RatePlanCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRatePlan, ObjectCode = availabilityRestriction.RatePlanCode });
        }
        if (errorDetailsList.Count > 0)
            return (errorDetailsList);

        foreach (var restriction in availabilityRestrictions)
        {
            var existingRestrictions = await _komoroContext.AvailabilityRestrictions
                .Include(ar => ar.Property)
                .Include(ar => ar.RoomType)
                .Where(ar => ar.Property.SupplierId == supplierId 
                    && ar.Property.Code == restriction.PropertyCode
                    && ar.RatePlanCode == restriction.RatePlanCode
                    && ar.RoomType.Code == restriction.RoomTypeCode
                    && ar.StartDate == restriction.StartDate 
                    && ar.EndDate == restriction.EndDate)
                .ToListAsync();
            var utcNow = _dateTimeOffsetProvider.UtcNow();

            if (restriction.RestrictionStatusDetails is not null)
                await AddOrUpdateRestrictionStatus(restriction, existingRestrictions);
            else if (restriction.StayDurationDetails is not null)
                await AddOrUpdateLengthOfStay(restriction, existingRestrictions);

            await _komoroContext.SaveChangesAsync();
        }

        return errorDetailsList;


        async Task AddOrUpdateRestrictionStatus(AvailabilityRestriction restriction, List<DataModels.AvailabilityRestriction> existingRestrictions)
        {
            var existingRestriction = existingRestrictions
                .SingleOrDefault(r => r.RestrictionStatusDetails.Restriction == restriction.RestrictionStatusDetails.Restriction);
            var utcNow = _dateTimeOffsetProvider.UtcNow();
            if (existingRestriction is null)
            {
                var propertyId = await _propertyService.GetId(supplierId, restriction.PropertyCode);
                var roomTypeId = await _roomTypeService.GetId(restriction.RoomTypeCode);
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
                var propertyId = await _propertyService.GetId(supplierId, restriction.PropertyCode);
                var roomTypeId = await _roomTypeService.GetId(restriction.RoomTypeCode);
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
