using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;

public static class AvailabilityRestrictionExtensions
{
    public static AvailStatusMessage ToAvailStatusMessage(this AvailabilityRestriction availabilityRestriction)
    {
        return new AvailStatusMessage
        {
            StatusApplicationControl = new StatusApplicationControl
            {
                Start = availabilityRestriction.StartDate.ToDateTime(TimeOnly.MinValue),
                End = availabilityRestriction.EndDate.ToDateTime(TimeOnly.MinValue),
                InvTypeCode = availabilityRestriction.RoomTypeCode,
                RatePlanCode = availabilityRestriction.RatePlanCode
            },
            RestrictionStatus = availabilityRestriction.RestrictionStatus is not null 
                ? GetRestrictionStatus(availabilityRestriction.RestrictionStatus) 
                : null,
            LengthsOfStay = availabilityRestriction.LengthOfStay is not null
                ? GetLengthsOfStay(availabilityRestriction.LengthOfStay)
                : null
        };


        static Models.Availabilities.RestrictionStatus GetRestrictionStatus(KomoroContracts.Availabilities.RestrictionStatus restrictionStatus)
        {
            return new Models.Availabilities.RestrictionStatus
            {
                Restriction = restrictionStatus.Restriction.HasValue
                    ? restrictionStatus.Restriction.ToString() 
                    : null,
                Status = restrictionStatus.Restriction.HasValue
                    ? restrictionStatus.Status.ToString()
                    : null,
                MinAdvancedBookingOffset = restrictionStatus.MinAdvancedBookingOffset.HasValue 
                    ? GetMinAdvancedBookingOffset(restrictionStatus.MinAdvancedBookingOffset.Value)
                    : null
            };
        }


        static LengthsOfStay GetLengthsOfStay(KomoroContracts.Availabilities.LengthOfStay lengthsOfStay)
        {
            return new LengthsOfStay
            {
                ArrivalDateBased = lengthsOfStay.IsArrivalDateBased,
                LengthOfStayList = new List<Models.Availabilities.LengthOfStay>
                {
                    new Models.Availabilities.LengthOfStay
                    {
                        MinMaxMessageType = "MinLOS",
                        TimeUnit = "Day",
                        Time = lengthsOfStay.MinimumDays
                    }
                }
            };
        }


        static string GetMinAdvancedBookingOffset(int minAdvancedBookingOffset)
        {
            return $"P{minAdvancedBookingOffset}D";
        }
    }
}
