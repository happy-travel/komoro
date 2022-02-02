﻿using CSharpFunctionalExtensions;
using HappyTravel.KomoroContracts.Statics;

namespace HappyTravel.Komoro.Api.Services;

public interface IRoomTypeService
{
    Task<List<RoomType>> Get(CancellationToken cancellationToken);
    Task<Result> Add(RoomType roomType, CancellationToken cancellationToken);
    Task<Result> Modify(int roomTypeId, RoomType roomType, CancellationToken cancellationToken);
    Task<Result> Remove(int roomTypeId, CancellationToken cancellationToken);
}
