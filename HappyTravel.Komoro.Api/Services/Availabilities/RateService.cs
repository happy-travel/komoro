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

public class RateService : IRateService
{
    public RateService(KomoroContext komoroContext, IDateTimeOffsetProvider dateTimeOffsetProvider, IPropertyService propertyService, 
        IRoomTypeService roomTypeService, IRatePlanService ratePlanService)
    {
        _komoroContext = komoroContext;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _propertyService = propertyService;
        _roomTypeService = roomTypeService;
        _ratePlanService = ratePlanService;
    }


    public async Task<(Rate, List<ErrorDetails>)> Get(RateRequest request)
    {
        if (!await _propertyService.IsExist(request.SupplierCode, request.PropertyCode))
            return (new(), new List<ErrorDetails>
                { new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidProperty, EntityCode = request.PropertyCode } });

        var errorDetailsList = new List<ErrorDetails>();
        foreach (var ratePlanCode in request.RatePlanCodes)
        {
            if (!_ratePlanService.IsExist(ratePlanCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRatePlan, EntityCode = ratePlanCode });
        }
        if (errorDetailsList.Count > 0)
            return (new(), errorDetailsList);

        var ratePlans = new List<RatePlan>();
        foreach (var ratePlanCode in request.RatePlanCodes)
        {
            var rateDetails = await _komoroContext.Rates
                .Include(i => i.Property)
                .Include(i => i.RoomType)
                .Where(i => i.Property.SupplierCode == request.SupplierCode
                    && i.Property.Code == request.PropertyCode
                    && request.RatePlanCodes.Contains(i.RoomType.Code)
                    && ((i.StartDate <= request.StartDate && i.EndDate >= request.EndDate)
                        || (i.StartDate >= request.StartDate && i.EndDate <= request.EndDate)
                        || (i.StartDate >= request.StartDate && i.StartDate <= request.EndDate)
                        || (i.EndDate >= request.StartDate && i.EndDate <= request.EndDate)))
                .Select(i => i.ToApiRateDetails())
                .ToListAsync();
            var ratePlan = new RatePlan
            {
                RatePlanCode = ratePlanCode,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                RateDetails = rateDetails
            };
            ratePlans.Add(ratePlan);
        }

        var rate = new Rate
        {
            SupplierCode = request.SupplierCode,
            PropertyCode = request.PropertyCode,
            RatePlans = ratePlans
        };

        return (rate, errorDetailsList);
    }


    public async Task<List<ErrorDetails>> Update(Rate rate)
    {
        var supplierCode = rate.SupplierCode;
        var propertyCode = rate.PropertyCode;
        if (!await _propertyService.IsExist(supplierCode, propertyCode))
            return (new List<ErrorDetails>
                { new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidProperty, EntityCode = propertyCode } });

        var errorDetailsList = new List<ErrorDetails>();
        foreach (var ratePlan in rate.RatePlans)
        {
            if (!_ratePlanService.IsExist(ratePlan.RatePlanCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRatePlan, EntityCode = ratePlan.RatePlanCode });

            foreach (var rateDetails in ratePlan.RateDetails)
            {
                if (!await _roomTypeService.IsExist(rateDetails.RoomTypeCode))
                    errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRoomType, EntityCode = rateDetails.RoomTypeCode });
            }
        }
        if (errorDetailsList.Count > 0)
            return (errorDetailsList);

        foreach (var ratePlan in rate.RatePlans)
        {
            foreach (var rateDetails in ratePlan.RateDetails)
            {
                var existingRatePlan = await _komoroContext.Rates
                    .Include(r => r.Property)
                    .Include(r => r.RoomType)
                    .SingleOrDefaultAsync(r => r.Property.SupplierCode == supplierCode
                        && r.Property.Code == propertyCode
                        && r.RatePlanCode == ratePlan.RatePlanCode
                        && r.RoomType.Code == rateDetails.RoomTypeCode
                        && r.StartDate == ratePlan.StartDate
                        && r.EndDate == ratePlan.EndDate);
                var utcNow = _dateTimeOffsetProvider.UtcNow();

                if (existingRatePlan is null)
                {
                    var propertyId = await _propertyService.GetId(supplierCode, propertyCode);
                    var roomTypeId = await _roomTypeService.GetId(rateDetails.RoomTypeCode);
                    var newRate = new DataModels.Rate
                    {
                        StartDate = ratePlan.StartDate,
                        EndDate = ratePlan.EndDate,
                        PropertyId = propertyId,
                        RoomTypeId = roomTypeId,
                        RatePlanCode = ratePlan.RatePlanCode,
                        BaseRates = rateDetails.BaseRates,
                        AdditionalRates = rateDetails.AdditionalRates,
                        Created = utcNow,
                        Modified = utcNow
                    };
                    _komoroContext.Rates.Add(newRate);
                }
                else
                {
                    existingRatePlan.BaseRates = rateDetails.BaseRates;
                    existingRatePlan.AdditionalRates = rateDetails.AdditionalRates;
                    existingRatePlan.Modified = utcNow;
                    _komoroContext.Rates.Update(existingRatePlan);
                }
            }
            await _komoroContext.SaveChangesAsync();
        }

        return errorDetailsList;
    }


    private readonly KomoroContext _komoroContext;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IPropertyService _propertyService;
    private readonly IRoomTypeService _roomTypeService;
    private readonly IRatePlanService _ratePlanService;
}
