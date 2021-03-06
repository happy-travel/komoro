using ApiModels = HappyTravel.KomoroContracts.Statics;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Statics;

public static class RoomTypeExtension
{
    public static ApiModels.RoomType ToApiRoomType(this DataModels.RoomType roomType)
    {
        return new ApiModels.RoomType
        {
            Id = roomType.Id,
            Code = roomType.Code,
            Name = roomType.Name,
            Category = roomType.Category
        };
    }
}
