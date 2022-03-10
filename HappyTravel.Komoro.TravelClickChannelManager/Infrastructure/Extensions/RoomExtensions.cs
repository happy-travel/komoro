using Responses = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;
using HappyTravel.KomoroContracts.Statics;

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
                    MaxAdultOccupancy = room.MaximumOccupancy[0].Adults,
                    MaxChildOccupancy = room.MaximumOccupancy[0].Children,
                    MaxInfantOccupancy = 0
                }
            }
        };
    }
}
