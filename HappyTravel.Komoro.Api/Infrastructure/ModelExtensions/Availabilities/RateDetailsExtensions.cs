using ApiModels = HappyTravel.KomoroContracts.Availabilities;
using DataModels = HappyTravel.Komoro.Data.Models.Availabilities;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;

public static class RateDetailsExtensions
{
    public static ApiModels.RateDetails ToApiRateDetails(this DataModels.Rate rate)
    {
        return new ApiModels.RateDetails
        {
            RoomTypeCode = rate.RoomType.Code,
            CurrencyCode = rate.Currency,
            BaseRates = rate.BaseRates,
            AdditionalRates = rate.AdditionalRates
        };
    }
}
