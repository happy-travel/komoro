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
            RestrictionStatus = availabilityRestriction.RestrictionStatusDetails is not null 
                ? GetRestrictionStatus(availabilityRestriction.RestrictionStatusDetails) 
                : null,
            LengthsOfStay = availabilityRestriction.StayDurationDetails is not null
                ? GetLengthsOfStay(availabilityRestriction.StayDurationDetails)
                : null
        };


        static RestrictionStatus GetRestrictionStatus(RestrictionStatusDetails restrictionStatusDetails)
        {
            return new RestrictionStatus
            {
                Restriction = restrictionStatusDetails.Restriction.HasValue
                    ? restrictionStatusDetails.Restriction.ToString() 
                    : null,
                Status = restrictionStatusDetails.Restriction.HasValue
                    ? restrictionStatusDetails.Status.ToString()
                    : null,
                MinAdvancedBookingOffset = restrictionStatusDetails.MinAdvancedBookingOffset.HasValue 
                    ? GetMinAdvancedBookingOffset(restrictionStatusDetails.MinAdvancedBookingOffset.Value)
                    : null
            };
        }


        static LengthsOfStay GetLengthsOfStay(StayDurationDetails stayDurationDetails)
        {
            return new LengthsOfStay
            {
                ArrivalDateBased = stayDurationDetails.IsArrivalDateBased,
                LengthOfStayList = new List<LengthOfStay>
                {
                    new LengthOfStay
                    {
                        MinMaxMessageType = MinMaxMessageType,
                        TimeUnit = TimeUnit,
                        Time = stayDurationDetails.MinimumDays
                    }
                }
            };
        }


        static string GetMinAdvancedBookingOffset(int minAdvancedBookingOffset)
        {
            return $"P{minAdvancedBookingOffset}D";
        }
    }


    private const string MinMaxMessageType = "MinLOS";
    private const string TimeUnit = "Day";
}
