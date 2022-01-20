﻿using ApiModels = HappyTravel.Komoro.Api.Models;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;

public static class RoomTypeExtension
{
    public static ApiModels.RoomType ToApiRoomType(this DataModels.RoomType roomType)
    {
        return new ApiModels.RoomType
        {
            Id = roomType.Id,
            Name = roomType.Name
        };
    }
}