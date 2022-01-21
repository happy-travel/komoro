using CsvHelper.Configuration;

namespace HappyTravel.Komoro.Api.Models.TravelClickCsv;

public sealed class RoomMap : ClassMap<Room>
{
    public RoomMap()
    {
        Map(r => r.RoomType).Index(1);
        Map(r => r.StandardMealPlan).Index(2);
        Map(r => r.StandardOccupancy).Index(3);
        Map(r => r.MaximumOccupancy).Index(4);
        Map(r => r.ExtraAdultSupplement).Index(5);
        Map(r => r.ChildSupplement).Index(6);
        Map(r => r.InfantSupplement).Index(7);
        Map(r => r.StandardRO).Index(8);
        Map(r => r.StandardBB).Index(9);
        Map(r => r.StaySaveRO).Index(10);
        Map(r => r.StaySaveBB).Index(11);
        Map(r => r.EarlyBirdRO).Index(12);
        Map(r => r.EarlyBirdBB).Index(13);
        Map(r => r.SpecialDealRO).Index(14);
        Map(r => r.SpecialDealBB).Index(15);
    }
}
