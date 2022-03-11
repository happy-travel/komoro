using Responses = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;
using HappyTravel.KomoroContracts.Statics;
using HappyTravel.KomoroContracts.Enums;

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
                    RoomTypeCode = room.RoomType.Id.ToString(), // TODO: Need clarify
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
                ratePlans.Add(new Responses.RatePlan
                {
                    RatePlanCode = "StandardRO",
                    RatePlanName = "Standard Room Only",
                    BaseOccupancy = room.StandardOccupancy.Adults,
                    CurrencyCode = DefaultCurrencyCode
                });
            
            if ((room.RatePlans & RatePlans.StandardBB) == RatePlans.StandardBB)
                ratePlans.Add(new Responses.RatePlan
                {
                    RatePlanCode = "StandardBB",
                    RatePlanName = "Standard Bed & Breakfast",
                    BaseOccupancy = room.StandardOccupancy.Adults,
                    CurrencyCode = DefaultCurrencyCode
                }); 
            
            if ((room.RatePlans & RatePlans.StaySaveRO) == RatePlans.StaySaveRO)
                ratePlans.Add(new Responses.RatePlan
                {
                    RatePlanCode = "StaySaveRO",
                    RatePlanName = "Stay Save Room Only",
                    BaseOccupancy = room.StandardOccupancy.Adults,
                    CurrencyCode = DefaultCurrencyCode
                });
            
            if ((room.RatePlans & RatePlans.StaySaveBB) == RatePlans.StaySaveBB)
                ratePlans.Add(new Responses.RatePlan
                {
                    RatePlanCode = "StaySaveBB",
                    RatePlanName = "Stay Save Bed & Breakfast",
                    BaseOccupancy = room.StandardOccupancy.Adults,
                    CurrencyCode = DefaultCurrencyCode
                });
            
            if ((room.RatePlans & RatePlans.EarlyBirdRO) == RatePlans.EarlyBirdRO)
                ratePlans.Add(new Responses.RatePlan
                {
                    RatePlanCode = "EarlyBirdRO",
                    RatePlanName = "Early Bird Room Only",
                    BaseOccupancy = room.StandardOccupancy.Adults,
                    CurrencyCode = DefaultCurrencyCode
                });
            
            if ((room.RatePlans & RatePlans.EarlyBirdBB) == RatePlans.EarlyBirdBB)
                ratePlans.Add(new Responses.RatePlan
                {
                    RatePlanCode = "EarlyBirdBB",
                    RatePlanName = "Early Bird Bed & Breakfast",
                    BaseOccupancy = room.StandardOccupancy.Adults,
                    CurrencyCode = DefaultCurrencyCode
                });

            if ((room.RatePlans & RatePlans.SpecialDealRO) == RatePlans.SpecialDealRO)
                ratePlans.Add(new Responses.RatePlan
                {
                    RatePlanCode = "SpecialDealRO",
                    RatePlanName = "Special Deal Room Only",
                    BaseOccupancy = room.StandardOccupancy.Adults,
                    CurrencyCode = DefaultCurrencyCode
                });

            if ((room.RatePlans & RatePlans.SpecialDealBB) == RatePlans.SpecialDealBB)
                ratePlans.Add(new Responses.RatePlan
                {
                    RatePlanCode = "SpecialDealBB",
                    RatePlanName = "Special Deal Bed & Breakfast",
                    BaseOccupancy = room.StandardOccupancy.Adults,
                    CurrencyCode = DefaultCurrencyCode
                });

            return ratePlans;
        }
    }


    private const string DefaultCurrencyCode = "USD";   // TODO: Need claify
}
