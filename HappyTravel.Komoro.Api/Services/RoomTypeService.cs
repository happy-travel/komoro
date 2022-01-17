using CSharpFunctionalExtensions;
using FluentValidation;
using HappyTravel.Komoro.Api.Infrastructure;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;
using HappyTravel.Komoro.Data;
using Microsoft.EntityFrameworkCore;
using ApiModels = HappyTravel.Komoro.Api.Models;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Services;

public class RoomTypeService : IRoomTypeService
{
    public RoomTypeService(KomoroContext komoroContext)
    {
        _komoroContext = komoroContext;
    }


    public async Task<List<ApiModels.RoomType>> Get(CancellationToken cancellationToken)
    {
        return await _komoroContext.RoomTypes.Select(rt => rt.ToApiRoomType())
            .ToListAsync(cancellationToken);
    }


    public async Task<Result> Add(ApiModels.RoomType apiRoomType, CancellationToken cancellationToken)
    {
        return await Validate(apiRoomType)
            .Tap(Add);


        async Task Add()
        {
            var utcNow = DateTimeOffset.UtcNow;
            var roomType = new DataModels.RoomType
            {
                Name = apiRoomType.Name,
                Created = utcNow,
                Modified = utcNow
            };

            _komoroContext.RoomTypes.Add(roomType);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Modify(int roomTypeId, ApiModels.RoomType apiRoomType, CancellationToken cancellationToken)
    {
        return await Validate(apiRoomType)
            .Bind(() => Get(roomTypeId, cancellationToken))
            .Tap(Update);


        async Task Update(DataModels.RoomType roomType)
        {
            roomType.Name = apiRoomType.Name;
            roomType.Modified = DateTimeOffset.UtcNow;

            _komoroContext.RoomTypes.Update(roomType);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Remove(int roomTypeId, CancellationToken cancellationToken)
    {
        return await Get(roomTypeId, cancellationToken)
            .Tap(Delete);


        async Task Delete(DataModels.RoomType roomType)
        {
            _komoroContext.RoomTypes.Remove(roomType);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    private static Result Validate(ApiModels.RoomType roomType)
        => GenericValidator<ApiModels.RoomType>.Validate(v =>
        {
            v.RuleFor(rt => rt.Name).NotEmpty();
        },
        roomType);


    private async Task<Result<DataModels.RoomType>> Get(int roomTypeId, CancellationToken cancellationToken)
    {
        var roomType = await _komoroContext.RoomTypes.SingleOrDefaultAsync(rt => rt.Id == roomTypeId, cancellationToken);
        
        return roomType is not null
            ? roomType
            : Result.Failure<DataModels.RoomType>($"Room type with id {roomTypeId} not found");
    }


    private readonly KomoroContext _komoroContext;
}
