using HappyTravel.KomoroContracts.Enums;

namespace HappyTravel.Komoro.Api.Services.Statics;

public class RoomCategoryService : IRoomCategoryService
{
    public List<string> Get()
    {
        var ratePlans = (RoomCategories[])Enum.GetValues(typeof(RoomCategories));

        return ratePlans.Select(rp => rp.ToString()).ToList();
    }
}
