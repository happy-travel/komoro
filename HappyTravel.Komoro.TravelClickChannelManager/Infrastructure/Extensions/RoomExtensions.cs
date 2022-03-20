using Responses = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;
using HappyTravel.KomoroContracts.Statics;
using HappyTravel.KomoroContracts.Enums;
using HappyTravel.Komoro.Common.Infrastructure.Extensions;

namespace HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;

public static class RoomExtensions
{
    public static Responses.HotelProduct ToHotelProduct(this Room room)
    {
        return new Responses.HotelProduct
        {
            RoomTypes = new List<Responses.RoomType>
            {
                new Responses.RoomType
                {
                    RoomTypeCode = room.RoomType.Code,
                    RoomTypeName = room.RoomType.Name,
                    MaxAdultOccupancy = GetMaximumAdults(room.MaximumOccupancy),
                    MaxChildOccupancy = GetMaximumChildren(room.MaximumOccupancy),
                    MaxInfantOccupancy = GetMaximumInfants(room.MaximumOccupancy)
                }
            },
            RatePlans = GetRatePlans(room)
        };


        static int GetMaximumAdults(List<Occupancy> occupancies)
        {
            return occupancies.Select(o => o.Adults).Max();
        }


        static int GetMaximumChildren(List<Occupancy> occupancies)
        {
            return occupancies.Select(o => o.Children).Max();
        }


        static int GetMaximumInfants(List<Occupancy> occupancies)
        {
            return occupancies.Select(o => o.Children).Max();
        }


        static List<Responses.RatePlan> GetRatePlans(Room room)
        {
            var ratePlans = new List<Responses.RatePlan>();

            if ((room.RatePlans & RatePlans.StandardRO) == RatePlans.StandardRO)
                ratePlans.Add(GetRatePlan(RatePlans.StandardRO, room.StandardOccupancy.Adults));
            
            if ((room.RatePlans & RatePlans.StandardBB) == RatePlans.StandardBB)
                ratePlans.Add(GetRatePlan(RatePlans.StandardBB, room.StandardOccupancy.Adults));

            if ((room.RatePlans & RatePlans.StaySaveRO) == RatePlans.StaySaveRO)
                ratePlans.Add(GetRatePlan(RatePlans.StaySaveRO, room.StandardOccupancy.Adults));

            if ((room.RatePlans & RatePlans.StaySaveBB) == RatePlans.StaySaveBB)
                ratePlans.Add(GetRatePlan(RatePlans.StaySaveBB, room.StandardOccupancy.Adults));

            if ((room.RatePlans & RatePlans.EarlyBirdRO) == RatePlans.EarlyBirdRO)
                ratePlans.Add(GetRatePlan(RatePlans.EarlyBirdRO, room.StandardOccupancy.Adults));

            if ((room.RatePlans & RatePlans.EarlyBirdBB) == RatePlans.EarlyBirdBB)
                ratePlans.Add(GetRatePlan(RatePlans.EarlyBirdBB, room.StandardOccupancy.Adults));

            if ((room.RatePlans & RatePlans.SpecialDealRO) == RatePlans.SpecialDealRO)
                ratePlans.Add(GetRatePlan(RatePlans.SpecialDealRO, room.StandardOccupancy.Adults));

            if ((room.RatePlans & RatePlans.SpecialDealBB) == RatePlans.SpecialDealBB)
                ratePlans.Add(GetRatePlan(RatePlans.SpecialDealBB, room.StandardOccupancy.Adults));

            return ratePlans;
        }


        static Responses.RatePlan GetRatePlan(RatePlans ratePlan, int numberAdults)
        {
            return new Responses.RatePlan
            {
                RatePlanCode = ratePlan.ToString(),
                RatePlanName = ratePlan.GetDescription(),
                BaseOccupancy = numberAdults,
                CurrencyCode = DefaultCurrencyCode
            };
        }
    }


    private const string DefaultCurrencyCode = "USD";   // TODO: Need claify
}
