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
            RestrictionStatusDetails = availStatusMessage.RestrictionStatus is not null
                ? GetRestrictionStatus(availStatusMessage.RestrictionStatus)
                : null,
            StayDurationDetails = availStatusMessage.LengthsOfStay is not null
                ? GetStayDurationDetails(availStatusMessage.LengthsOfStay)
                : null
        };


        static RestrictionStatusDetails GetRestrictionStatus(RestrictionStatus restrictionStatus)
        {
            return new RestrictionStatusDetails
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
                MasterRestriction => RestrictionTypes.Master,
                ArrivalRestriction => RestrictionTypes.Arrival,
                _ => throw new NotImplementedException(),
            };
        }


        static RestrictionStatuses GetStatus(string status)
        {
            return status switch
            {
                OpenStatus => RestrictionStatuses.Open,
                CloseStatus => RestrictionStatuses.Close,
                _ => throw new NotImplementedException(),
            };
        }


        static int GetMinAdvancedBookingOffset(string minAdvancedBookingOffset)
        {
            var numberOfDays = 0;
            if (minAdvancedBookingOffset.Length >= 3)
                _ = int.TryParse(minAdvancedBookingOffset.AsSpan(1, minAdvancedBookingOffset.Length - 2), out numberOfDays);

            return numberOfDays;
        }


        static StayDurationDetails GetStayDurationDetails(LengthsOfStay lengthsOfStay)
        {
            return new StayDurationDetails
            {
                IsArrivalDateBased = lengthsOfStay.ArrivalDateBased,
                MinimumDays = lengthsOfStay.LengthOfStayList[0].Time
            };
        }
    }


    private const string MasterRestriction = "Master";
    private const string ArrivalRestriction = "Arrival";
    private const string OpenStatus = "Open";
    private const string CloseStatus = "Close";
}
