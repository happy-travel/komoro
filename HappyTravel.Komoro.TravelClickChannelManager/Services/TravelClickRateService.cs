using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;
using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public class TravelClickRateService : ITravelClickRateService
{
    public TravelClickRateService(IDateTimeOffsetProvider dateTimeOffsetProvider, IRateService rateService)
    {
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _rateService = rateService;
    }


    public async Task<OtaHotelRatePlanRS> Get(OtaHotelRatePlanRQ otaHotelRatePlanRQ, CancellationToken cancellationToken)
    {
        var request = otaHotelRatePlanRQ.RatePlans.Single();
        var hotelCode = request.HotelRef.HotelCode;

        Success? success = null;
        List<Warning>? warnings = null;
        List<Error>? errors = null;
        Models.Availabilities.RatePlans ratePlans = new();

        var rateRequest = new RateRequest
        {
            SupplierCode = Constants.TravelClickCode,
            PropertyCode = hotelCode,
            StartDate = DateOnly.FromDateTime(request.DateRange.Start),
            EndDate = DateOnly.FromDateTime(request.DateRange.End),
            RatePlanCodes = request.RatePlanCandidates.Select(rpc => rpc.RatePlanCode).ToList()
        };

        var (rate, errorDetails) = await _rateService.Get(rateRequest);

        if (errorDetails.Any())
        {
            errors = errorDetails.Select(ed => ed.ToError())
                .ToList();
        }
        else
        {
            success = new();
            var ratePlanList = rate.RatePlans.Select(rp => rp.ToRatePlan())
                .ToList();

            ratePlans = new Models.Availabilities.RatePlans
            {
                HotelCode = hotelCode,
                PatePlanList = ratePlanList
            };
        }

        return new OtaHotelRatePlanRS
        {
            Version = otaHotelRatePlanRQ.Version,
            TimeStamp = _dateTimeOffsetProvider.UtcNow(),
            EchoToken = otaHotelRatePlanRQ.EchoToken,
            Success = success,
            Errors = errors,
            Warnings = warnings,
            RatePlans = ratePlans
        };
    }


    public async Task<OtaHotelRatePlanNotifRS> Update(OtaHotelRatePlanNotifRQ otaHotelRatePlanNotifRQ, CancellationToken cancellationToken)
    {
        var hotelCode = otaHotelRatePlanNotifRQ.RatePlans.HotelCode ?? string.Empty;

        Success? success = null;
        List<Warning>? warnings = null;
        List<Error>? errors = null;

        var rate = new Rate
        {
            SupplierCode = Constants.TravelClickCode,
            PropertyCode = hotelCode,
            RatePlans = otaHotelRatePlanNotifRQ.RatePlans.PatePlanList.Select(rp => rp.ToContractRatePlan()).ToList()
        };

        var errorDetails = await _rateService.Update(rate);
        if (errorDetails.Any())
        {
            errors = errorDetails.Select(ed => ed.ToError())
                .ToList();
        }
        else
        {
            success = new();
        }

        return new OtaHotelRatePlanNotifRS
        {
            Version = otaHotelRatePlanNotifRQ.Version,
            TimeStamp = _dateTimeOffsetProvider.UtcNow(),
            EchoToken = otaHotelRatePlanNotifRQ.EchoToken,
            Success = success,
            Errors = errors,
            Warnings = warnings
        };
    }


    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IRateService _rateService;
}
