using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;
using HappyTravel.KomoroContracts.Availabilities;
using HappyTravel.KomoroContracts.Enums;

namespace HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;

public static class AvailStatusMessageExtensions
{
    public static AvailabilityRestriction ToAvailabilityRestriction(this AvailStatusMessage availStatusMessage)
    {
        return new AvailabilityRestriction
        {
            StartDate = DateOnly.FromDateTime(availStatusMessage.StatusApplicationControl.Start),
            EndDate = DateOnly.FromDateTime(availStatusMessage.StatusApplicationControl.End),
            RoomTypeCode = availStatusMessage.StatusApplicationControl.InvTypeCode,
            RatePlanCode = availStatusMessage.StatusApplicationControl.RatePlanCode,
            RestrictionStatus = availStatusMessage.RestrictionStatus is not null
                ? GetRestrictionStatus(availStatusMessage.RestrictionStatus)
                : null,
            LengthOfStay = availStatusMessage.LengthsOfStay is not null
                ? GetLengthOfStay(availStatusMessage.LengthsOfStay)
                : null
        };


        static KomoroContracts.Availabilities.RestrictionStatus GetRestrictionStatus(Models.Availabilities.RestrictionStatus restrictionStatus)
        {
            return new KomoroContracts.Availabilities.RestrictionStatus
            {
                Restriction = restrictionStatus.Restriction is not null
                    ? GetRestriction(restrictionStatus.Restriction)
                    : null,
                Status = restrictionStatus.Status is not null
                    ? GetStatus(restrictionStatus.Status)
                    : null,
                MinAdvancedBookingOffset = restrictionStatus.MinAdvancedBookingOffset is not null
                    ? GetMinAdvancedBookingOffset(restrictionStatus.MinAdvancedBookingOffset)
                    : null
            };
        }


        static RestrictionTypes GetRestriction(string restriction)
        {
            return restriction switch
            {
                "Master" => RestrictionTypes.Master,
                "Arrival" => RestrictionTypes.Arrival,
                _ => throw new NotImplementedException(),
            };
        }


        static RestrictionStatuses GetStatus(string status)
        {
            return status switch
            {
                "Open" => RestrictionStatuses.Open,
                "Close" => RestrictionStatuses.Close,
                _ => throw new NotImplementedException(),
            };
        }


        static int GetMinAdvancedBookingOffset(string minAdvancedBookingOffset)
        {
            var numberOfDays = 0;
            if (minAdvancedBookingOffset.Length >= 3)
                _ = int.TryParse(minAdvancedBookingOffset.Substring(1, minAdvancedBookingOffset.Length - 2), out numberOfDays);

            return numberOfDays;
        }


        static KomoroContracts.Availabilities.LengthOfStay GetLengthOfStay(LengthsOfStay lengthsOfStay)
        {
            return new KomoroContracts.Availabilities.LengthOfStay
            {
                IsArrivalDateBased = lengthsOfStay.ArrivalDateBased,
                MinimumDays = lengthsOfStay.LengthOfStayList[0].Time
            };
        }
    }
}
