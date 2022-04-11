using ApiModels = HappyTravel.KomoroContracts.Availabilities;
using DataModels = HappyTravel.Komoro.Data.Models.Availabilities;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;

public static class AvailabilityRestrictionExtension
{
    public static ApiModels.AvailabilityRestriction ToApiAvailabilityRestriction(this DataModels.AvailabilityRestriction availabilityRestriction)
    {
        return new ApiModels.AvailabilityRestriction
        {
            Id = availabilityRestriction.Id,
            PropertyId = availabilityRestriction.PropertyId,
            StartDate = availabilityRestriction.StartDate,
            EndDate = availabilityRestriction.EndDate,
            RoomTypeId = availabilityRestriction.RoomTypeId,
            RatePlanCode = availabilityRestriction.RatePlanCode,
            RestrictionStatus = new ApiModels.RestrictionStatus
            {

            },
            LengthOfStay = new ApiModels.LengthOfStay
            {

            }
        };
    }
}
