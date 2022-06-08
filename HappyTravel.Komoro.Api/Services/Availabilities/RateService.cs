using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;
using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.Common.Services.Statics;
using HappyTravel.Komoro.Data;
using HappyTravel.KomoroContracts;
using HappyTravel.KomoroContracts.Availabilities;
using Microsoft.EntityFrameworkCore;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public class RateService : IRateService
{
    public RateService(KomoroContext komoroContext, IDateTimeOffsetProvider dateTimeOffsetProvider, IPropertyService propertyService, 
        IRatePlanService ratePlanService)
    {
        _komoroContext = komoroContext;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _propertyService = propertyService;
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
            if (!await _ratePlanService.IsExist(ratePlanCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRatePlan, EntityCode = ratePlanCode });
        }
        if (errorDetailsList.Count > 0)
            return (new(), errorDetailsList);

        var ratePlans = await _komoroContext.Rates
            .Include(i => i.Property)
            .Include(i => i.RoomType)
            .Where(i => i.Property.SupplierCode == request.SupplierCode
                && i.Property.Code == request.PropertyCode
                && request.RatePlanCodes.Contains(i.RoomType.Code)
                && ((i.StartDate <= request.StartDate && i.EndDate >= request.EndDate)
                    || (i.StartDate >= request.StartDate && i.EndDate <= request.EndDate)
                    || (i.StartDate >= request.StartDate && i.StartDate <= request.EndDate)
                    || (i.EndDate >= request.StartDate && i.EndDate <= request.EndDate)))
            .Select(i => i.ToApiRatePlan())
            .ToListAsync();

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
        throw new NotImplementedException();
    }


    private readonly KomoroContext _komoroContext;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IPropertyService _propertyService;
    private readonly IRatePlanService _ratePlanService;
}
