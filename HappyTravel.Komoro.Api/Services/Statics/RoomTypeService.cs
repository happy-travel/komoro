using CSharpFunctionalExtensions;
using FluentValidation;
using HappyTravel.Komoro.Api.Infrastructure;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Statics;
using HappyTravel.Komoro.Data;
using Microsoft.EntityFrameworkCore;
using ApiModels = HappyTravel.KomoroContracts.Statics;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Services.Statics;

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
            .Ensure(() => RoomTypeHasNoDuplicates(apiRoomType), "Adding room type has duplicate")
            .Tap(Add);


        async Task<bool> RoomTypeHasNoDuplicates(ApiModels.RoomType roomType)
            => !await _komoroContext.RoomTypes.Where(rt => rt.Name == roomType.Name)
                .AnyAsync(cancellationToken);


        async Task Add()
        {
            var utcNow = DateTimeOffset.UtcNow;
            var roomType = new DataModels.RoomType
            {
                Code = apiRoomType.Code,
                Name = apiRoomType.Name,
                Category = apiRoomType.Category,
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
            .Ensure(() => RoomTypeHasNoDuplicates(apiRoomType), "Modifiable room type has duplicate")
            .Bind(() => Get(roomTypeId, cancellationToken))
            .Tap(Update);


        async Task<bool> RoomTypeHasNoDuplicates(ApiModels.RoomType roomType)
            => !await _komoroContext.RoomTypes.Where(rt => rt.Name == roomType.Name && rt.Id != roomTypeId)
                .AnyAsync(cancellationToken);


        async Task Update(DataModels.RoomType roomType)
        {
            roomType.Code = apiRoomType.Code;
            roomType.Name = apiRoomType.Name;
            roomType.Category = apiRoomType.Category;
            roomType.Modified = DateTimeOffset.UtcNow;

            _komoroContext.RoomTypes.Update(roomType);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Remove(int roomTypeId, CancellationToken cancellationToken)
    {
        return await Get(roomTypeId, cancellationToken)
            .Tap(Remove);


        async Task Remove(DataModels.RoomType roomType)
        {
            _komoroContext.RoomTypes.Remove(roomType);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    private static Result Validate(ApiModels.RoomType roomType)
        => GenericValidator<ApiModels.RoomType>.Validate(v =>
        {
            v.RuleFor(rt => rt.Code).NotEmpty();
            v.RuleFor(rt => rt.Name).NotEmpty();
            v.RuleFor(rt => rt.Category).NotEmpty();
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
