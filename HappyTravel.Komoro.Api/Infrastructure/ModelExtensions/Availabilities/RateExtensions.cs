using ApiModels = HappyTravel.KomoroContracts.Availabilities;
using DataModels = HappyTravel.Komoro.Data.Models.Availabilities;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;

public static class RateExtensions
{
    public static ApiModels.RatePlan ToApiRatePlan(this DataModels.Rate rate)
    {
        return new ApiModels.RatePlan
        {
            StartDate = rate.StartDate,
            EndDate = rate.EndDate,
            RatePlanCode = rate.RatePlanCode,
            RateDetails = new List<ApiModels.RateDetails>
            {
                new ApiModels.RateDetails
                {
                    RoomTypeCode = 
                }
            }
        };
    }
}
