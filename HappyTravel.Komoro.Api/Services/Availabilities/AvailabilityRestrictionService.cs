using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;
using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.Common.Services.Statics;
using HappyTravel.Komoro.Data;
using HappyTravel.KomoroContracts;
using HappyTravel.KomoroContracts.Availabilities;
using Microsoft.EntityFrameworkCore;
using DataModels = HappyTravel.Komoro.Data.Models.Availabilities;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public class AvailabilityRestrictionService : IAvailabilityRestrictionService
{
    public AvailabilityRestrictionService(KomoroContext komoroContext, IDateTimeOffsetProvider dateTimeOffsetProvider, 
        IPropertyService propertyService, IRoomTypeService roomTypeService, IRatePlanService ratePlanService)
    {
        _komoroContext = komoroContext;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _propertyService = propertyService;
        _roomTypeService = roomTypeService;
        _ratePlanService = ratePlanService;
    }


    public async Task<(List<AvailabilityRestriction>, List<ErrorDetails>)> Get(AvailabilityRestrictionRequest request)
    {
        if (!await _propertyService.IsExist(request.SupplierCode, request.PropertyCode))
            return (new(0), new List<ErrorDetails> 
                { new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidProperty, EntityCode = request.PropertyCode } });

        var errorDetailsList = new List<ErrorDetails>();        
        foreach (var roomTypeCode in request.RoomTypeCodes)
        {
            if (!await _roomTypeService.IsExist(roomTypeCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRoomType, EntityCode = roomTypeCode });
        }
        foreach (var ratePlanCode in request.RatePlanCodes)
        {
            if (!_ratePlanService.IsExist(ratePlanCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRatePlan, EntityCode = ratePlanCode });
        }
        if (errorDetailsList.Count > 0)
            return (new(0), errorDetailsList);

        var availabilityRestrictions = await _komoroContext.AvailabilityRestrictions
            .Include(ar => ar.Property)
            .Include(ar => ar.RoomType)
            .Where(ar => ar.Property.SupplierCode == request.SupplierCode
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


    public async Task<List<ErrorDetails>> Update(string supplierCode, List<AvailabilityRestriction> availabilityRestrictions)
    {
        var propertyCode = availabilityRestrictions.First().PropertyCode;   // All availability offers are always requested from one property
        var propertyId = await _propertyService.GetId(supplierCode, propertyCode);
        if (propertyId is 0)
            return (new List<ErrorDetails>
                { new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidProperty, EntityCode = propertyCode } });

        var errorDetailsList = new List<ErrorDetails>();
        foreach (var availabilityRestriction in availabilityRestrictions)
        {
            if (!await _roomTypeService.IsExist(availabilityRestriction.RoomTypeCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRoomType, EntityCode = availabilityRestriction.RoomTypeCode });
            
            if (!_ratePlanService.IsExist(availabilityRestriction.RatePlanCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRatePlan, EntityCode = availabilityRestriction.RatePlanCode });
        }
        if (errorDetailsList.Count > 0)
            return (errorDetailsList);

        foreach (var restriction in availabilityRestrictions)
        {
            var roomTypeId = await _roomTypeService.GetId(restriction.RoomTypeCode);
            var existingRestrictions = await _komoroContext.AvailabilityRestrictions
                .Where(ar => ar.Property.SupplierCode == supplierCode 
                    && ar.PropertyId == propertyId
                    && ar.RatePlanCode == restriction.RatePlanCode
                    && ar.RoomTypeId == roomTypeId
                    && ar.StartDate == restriction.StartDate 
                    && ar.EndDate == restriction.EndDate)
                .ToListAsync();
            var utcNow = _dateTimeOffsetProvider.UtcNow();

            if (restriction.RestrictionStatusDetails is not null)
                await AddOrUpdateRestrictionStatus(restriction, existingRestrictions);
            else if (restriction.StayDurationDetails is not null)
                await AddOrUpdateLengthOfStay(restriction, existingRestrictions);
        }

        return errorDetailsList;


        async Task AddOrUpdateRestrictionStatus(AvailabilityRestriction restriction, List<DataModels.AvailabilityRestriction> existingRestrictions)
        {
            var existingRestriction = existingRestrictions
                .SingleOrDefault(r => r.RestrictionStatusDetails?.Restriction == restriction.RestrictionStatusDetails.Restriction 
                    && r.RestrictionStatusDetails?.MinAdvancedBookingOffset.HasValue == restriction.RestrictionStatusDetails.MinAdvancedBookingOffset.HasValue);
            var utcNow = _dateTimeOffsetProvider.UtcNow();
            if (existingRestriction is null)
            {
                var propertyId = await _propertyService.GetId(supplierCode, restriction.PropertyCode);
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
            await _komoroContext.SaveChangesAsync();
        }


        async Task AddOrUpdateLengthOfStay(AvailabilityRestriction restriction, List<DataModels.AvailabilityRestriction> existingRestrictions)
        {
            var existingRestriction = existingRestrictions
                .SingleOrDefault(r => r.StayDurationDetails is not null);
            var utcNow = _dateTimeOffsetProvider.UtcNow();
            if (existingRestriction is null)
            {
                var propertyId = await _propertyService.GetId(supplierCode, restriction.PropertyCode);
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
            await _komoroContext.SaveChangesAsync();
        }
    }


    private readonly KomoroContext _komoroContext;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IPropertyService _propertyService;
    private readonly IRoomTypeService _roomTypeService;
    private readonly IRatePlanService _ratePlanService;
}
