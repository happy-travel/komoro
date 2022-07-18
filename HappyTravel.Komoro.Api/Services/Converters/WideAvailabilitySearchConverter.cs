using HappyTravel.EdoContracts.Accommodations;
using HappyTravel.EdoContracts.Accommodations.Enums;
using HappyTravel.EdoContracts.Accommodations.Internals;
using HappyTravel.EdoContracts.General;
using HappyTravel.EdoContracts.General.Enums;
using HappyTravel.Komoro.Data.Models.Availabilities;
using HappyTravel.Komoro.Data.Models.Statics;
using HappyTravel.Money.Models;

namespace HappyTravel.Komoro.Api.Services.Converters
{
    public class WideAvailabilitySearchConverter
    {
        public static RoomContract Convert(Inventory inventory, Room room, List<Data.Models.Availabilities.Rate> rates, 
            Deadline deadline, RoomOccupationRequest roomOccupationRequest, AvailabilityRequest availabilityRequest)
        {
            var dailyRoomRates = GetDailyRoomRates(rates, availabilityRequest.CheckInDate, availabilityRequest.CheckOutDate);

            return new RoomContract(boardBasis: GetBoardBasis(inventory.RatePlanCode),
                mealPlan: room.MealPlan.Name,
                contractTypeCode: 0,    // Need clarify
                isAvailableImmediately: true,
                isDynamic: false,
                contractDescription: "",    // Need clarify
                remarks: new List<KeyValuePair<string, string>>(),
                dailyRoomRates: dailyRoomRates,
                rate: GetRate(dailyRoomRates),
                adultsNumber: roomOccupationRequest.AdultsNumber,
                childrenAges: roomOccupationRequest.ChildrenAges, 
                type: roomOccupationRequest.Type,
                isExtraBedNeeded: roomOccupationRequest.IsExtraBedNeeded,
                deadline: deadline,
                isAdvancePurchaseRate: false);


            static EdoContracts.General.Rate GetRate(List<DailyRate> dailyRates)
            {
                var finalPriceAmount = dailyRates.Sum(dr => dr.FinalPrice.Amount);
                var currency = dailyRates.First().Currency;
                var finalPrice = new MoneyAmount(finalPriceAmount, currency);

                return new EdoContracts.General.Rate(finalPrice: finalPrice, 
                    gross: finalPrice, 
                    discounts: null, 
                    type: PriceTypes.Room, 
                    description: null);
            }


            static List<DailyRate> GetDailyRoomRates(List<Data.Models.Availabilities.Rate> rates, DateTimeOffset checkInDate, DateTimeOffset checkOutDate)
            {
                var days = (checkOutDate - checkInDate).Days;
                var dailyRates = new List<DailyRate>();
                for (int i = 0; i < days; i++)
                {
                    var fromDate = checkInDate.AddDays(i);
                    var toDate = checkInDate.AddDays(i + 1);
                    var rate = rates.Single(r => r.StartDate <= DateOnly.FromDateTime(fromDate.Date) 
                        && r.EndDate >= DateOnly.FromDateTime(toDate.Date));
                    var finalPrice = GetFinalPrice(rate);

                    var dailyRate = new DailyRate(fromDate: fromDate,
                        toDate: toDate, 
                        finalPrice: finalPrice, 
                        gross: finalPrice, 
                        type: PriceTypes.Room, 
                        description: null);
                    dailyRates.Add(dailyRate);
                }

                return dailyRates;


                static MoneyAmount GetFinalPrice(Data.Models.Availabilities.Rate rate)
                {
                    var amountAfterTax = rate.BaseRates!.Where(br => br.AmountAfterTax != 0m).First().AmountAfterTax;   // TODO: Need clarify
                    
                    return new MoneyAmount(amountAfterTax, rate.Currency);
                }
            }
        }


        private static BoardBasisTypes GetBoardBasis(string ratePlanCode)
            => ratePlanCode switch
            {
                "StandardRO" => BoardBasisTypes.RoomOnly,
                "StandardBB" => BoardBasisTypes.BedAndBreakfast,
                "StaySaveRO" => BoardBasisTypes.RoomOnly,
                "StaySaveBB" => BoardBasisTypes.BedAndBreakfast,
                "EarlyBirdRO" => BoardBasisTypes.RoomOnly,
                "EarlyBirdBB" => BoardBasisTypes.BedAndBreakfast,
                "SpecialDealRO" => BoardBasisTypes.RoomOnly,
                "SpecialDealBB" => BoardBasisTypes.BedAndBreakfast,
                _ => throw new NotImplementedException("Uncorrect rateplan code")
            };
    }
}
