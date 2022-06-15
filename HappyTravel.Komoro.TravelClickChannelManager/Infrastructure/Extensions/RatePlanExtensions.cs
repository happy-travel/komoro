using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;
using HappyTravel.Money.Enums;
using Contracts = HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;

public static class RatePlanExtensions
{
    public static RatePlan ToRatePlan(this Contracts.RatePlan ratePlan)
    {
        return new RatePlan
        {
            Start = ratePlan.StartDate.ToDateTime(TimeOnly.MinValue),
            End = ratePlan.EndDate.ToDateTime(TimeOnly.MinValue),
            RatePlanCode = ratePlan.RatePlanCode,
            Rates = ratePlan.RateDetails.Select(rd => rd.ToRate())
                .ToList()
        };
    }


    public static Contracts.RatePlan ToContractRatePlan(this RatePlan ratePlan)
    {
        return new Contracts.RatePlan
        {
            StartDate = DateOnly.FromDateTime(ratePlan.Start),
            EndDate = DateOnly.FromDateTime(ratePlan.End),
            RatePlanCode = ratePlan.RatePlanCode,
            RateDetails = ratePlan.Rates.Select(r => r.ToRateDetails()).ToList()
        };
    }


    private static Rate ToRate(this Contracts.RateDetails rateDetails)
    {
        return new Rate
        {
            InvTypeCode = rateDetails.RoomTypeCode,
            CurrencyCode = rateDetails.CurrencyCode,
            BaseByGuestAmts = rateDetails.BaseRates?.Select(br => br.ToBaseByGuestAmt())
                .ToList(),
            AdditionalGuestAmounts = rateDetails.AdditionalRates?.Select(ar => ar.ToAdditionalGuestAmount())
                .ToList()
        };
    }


    private static BaseByGuestAmt ToBaseByGuestAmt(this Contracts.BaseRate baseRate)
    {
        return new BaseByGuestAmt
        {
            AmountBeforeTax = baseRate.AmountBeforeTax,
            AmountAfterTax = baseRate.AmountAfterTax,
            NumberOfGuests = baseRate.NumberOfGuests ?? 0,
            AgeQualifyingCode = baseRate.AgeQualifyingCode.ToString()
        };
    }


    private static AdditionalGuestAmount ToAdditionalGuestAmount(this Contracts.AdditionalRate additionalRate)
    {
        return new AdditionalGuestAmount
        {
            Amount = additionalRate.Amount,
            AgeQualifyingCode = additionalRate.AgeQualifyingCode.ToString()
        };
    }


    private static Contracts.RateDetails ToRateDetails(this Rate rate)
    {
        return new Contracts.RateDetails
        {
            RoomTypeCode = rate.InvTypeCode,
            CurrencyCode = rate.CurrencyCode,
            BaseRates = rate.BaseByGuestAmts?.Select(ba => ba.ToBaseRate()).ToList(),
            AdditionalRates = rate.AdditionalGuestAmounts?.Select(aa => aa.ToAdditionalRate()).ToList()
        };
    }


    private static Contracts.BaseRate ToBaseRate(this BaseByGuestAmt baseByGuestAmt)
    {
        return new Contracts.BaseRate
        {
            AmountBeforeTax = baseByGuestAmt.AmountBeforeTax,
            AmountAfterTax = baseByGuestAmt.AmountAfterTax,
            NumberOfGuests = baseByGuestAmt.NumberOfGuests,
            AgeQualifyingCode = int.TryParse(baseByGuestAmt.AgeQualifyingCode, out var ageQualifyingCode) ? ageQualifyingCode : null
        };
    }


    private static Contracts.AdditionalRate ToAdditionalRate(this AdditionalGuestAmount additionalGuestAmount)
    {
        return new Contracts.AdditionalRate
        {
            Amount = additionalGuestAmount.Amount,
            AgeQualifyingCode = int.TryParse(additionalGuestAmount.AgeQualifyingCode, out var ageQualifyingCode) ? ageQualifyingCode : null
        };
    }
}
