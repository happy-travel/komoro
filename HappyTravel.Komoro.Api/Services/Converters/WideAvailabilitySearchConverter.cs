using HappyTravel.EdoContracts.Accommodations.Enums;
using HappyTravel.EdoContracts.Accommodations.Internals;
using HappyTravel.EdoContracts.General;
using HappyTravel.Komoro.Data.Models.Availabilities;

namespace HappyTravel.Komoro.Api.Services.Converters
{
    public class WideAvailabilitySearchConverter
    {
        public static RoomContract Convert(Inventory inventory, RoomOccupationRequest request)
        {
            return new RoomContract(boardBasis: GetBoardBasis(inventory.RatePlanCode),
                mealPlan: "",   // Need clarify
                contractTypeCode: 0,    // Need clarify
                isAvailableImmediately: true,
                isDynamic: false,
                contractDescription: "",    // Need clarify
                remarks: new List<KeyValuePair<string, string>>(),
                dailyRoomRates: new List<DailyRate>(),  // Need clarify
                rate: new EdoContracts.General.Rate(),  // Need clarify
                adultsNumber: request.AdultsNumber,
                childrenAges: request.ChildrenAges, 
                type: request.Type,
                isExtraBedNeeded: request.IsExtraBedNeeded,
                deadline: default,  // Need clarify
                isAdvancePurchaseRate: false);
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
