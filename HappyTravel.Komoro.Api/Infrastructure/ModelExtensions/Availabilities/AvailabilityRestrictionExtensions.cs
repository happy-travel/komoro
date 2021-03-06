using ApiModels = HappyTravel.KomoroContracts.Availabilities;
using DataModels = HappyTravel.Komoro.Data.Models.Availabilities;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;

public static class AvailabilityRestrictionExtensions
{
    public static ApiModels.AvailabilityRestriction ToApiAvailabilityRestriction(this DataModels.AvailabilityRestriction availabilityRestriction)
    {
        return new ApiModels.AvailabilityRestriction
        {
            PropertyCode = availabilityRestriction.Property.Code,
            StartDate = availabilityRestriction.StartDate,
            EndDate = availabilityRestriction.EndDate,
            RoomTypeCode = availabilityRestriction.RoomType.Code,
            RatePlanCode = availabilityRestriction.RatePlanCode,
            RestrictionStatusDetails = availabilityRestriction.RestrictionStatusDetails,
            StayDurationDetails = availabilityRestriction.StayDurationDetails
        };
    }
}
