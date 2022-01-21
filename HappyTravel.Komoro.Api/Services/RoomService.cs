using CSharpFunctionalExtensions;
using FluentValidation;
using HappyTravel.Komoro.Api.Infrastructure;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;
using HappyTravel.Komoro.Data;
using Microsoft.EntityFrameworkCore;
using ApiModels = HappyTravel.Komoro.Api.Models;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Services;

public class RoomService : IRoomService
{
    public RoomService(KomoroContext komoroContext)
    {
        _komoroContext = komoroContext;
    }


    public async Task<List<ApiModels.Room>> Get(int propertyId, CancellationToken cancellationToken)
    {
        return await _komoroContext.Rooms.Where(r => r.PropertyId == propertyId)
            .Include(r => r.MealPlan)
            .Include(r => r.RoomType)
            .Select(r => r.ToApiRoom())
            .ToListAsync(cancellationToken);
    }


    public async Task<Result> Add(int propertyId, ApiModels.Room apiRoom, CancellationToken cancellationToken)
    {
        return await Validate(apiRoom)
            .Tap(Add);


        async Task Add()
        {
            var room = new DataModels.Room
            {
                PropertyId = apiRoom.PropertyId,
                RoomTypeId = apiRoom.RoomType.Id,
                StandardMealPlanId = apiRoom.StandardMealPlan.Id,
                StandardOccupancy = apiRoom.StandardOccupancy,
                MaximumOccupancy = apiRoom.MaximumOccupancy,
                ExtraAdultSupplement = apiRoom.ExtraAdultSupplement,
                ChildSupplement = apiRoom.ChildSupplement,
                InfantSupplement = apiRoom.InfantSupplement,
                RatePlans = apiRoom.RatePlans,
                Created = DateTimeOffset.UtcNow
            };

            _komoroContext.Rooms.Add(room);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Modify(int propertyId, int roomId, ApiModels.Room apiRoom, CancellationToken cancellationToken)
    {
        return await Validate(apiRoom)
            .Bind(() => Get(propertyId, roomId, cancellationToken))
            .Tap(Update);

        async Task Update(DataModels.Room room)
        {
            room.RoomTypeId = apiRoom.RoomType.Id;
            room.StandardMealPlanId = apiRoom.StandardMealPlan.Id;
            room.StandardOccupancy = apiRoom.StandardOccupancy;
            room.MaximumOccupancy = apiRoom.MaximumOccupancy;
            room.ExtraAdultSupplement = apiRoom.ExtraAdultSupplement;
            room.ChildSupplement = apiRoom.ChildSupplement;
            room.InfantSupplement = apiRoom.InfantSupplement;
            room.RatePlans = apiRoom.RatePlans;
            room.Modified = DateTimeOffset.UtcNow;

            _komoroContext.Rooms.Update(room);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Remove(int propertyId, int roomId, CancellationToken cancellationToken)
    {
        return await Get(propertyId, roomId, cancellationToken)
            .Tap(Remove);


        async Task Remove(DataModels.Room room)
        {
            _komoroContext.Rooms.Remove(room);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    private static Result Validate(ApiModels.Room room)
        => GenericValidator<ApiModels.Room>.Validate(v =>
        {
            v.RuleFor(r => r.PropertyId).NotEmpty();
            v.RuleFor(r => r.RoomType).NotEmpty();
            v.RuleFor(r => r.StandardMealPlan).NotEmpty();
            v.RuleFor(r => r.StandardOccupancy).NotEmpty();
            v.RuleFor(r => r.MaximumOccupancy).NotEmpty();
            v.RuleFor(r => r.ExtraAdultSupplement).NotEmpty();
            v.RuleFor(r => r.ChildSupplement).NotEmpty();
            v.RuleFor(r => r.InfantSupplement).NotEmpty();
            v.RuleFor(r => r.RatePlans).NotEmpty();
        },
        room);


    private async Task<Result<DataModels.Room>> Get(int propertyId, int roomId, CancellationToken cancellationToken)
    {
        var room = await _komoroContext.Rooms.SingleOrDefaultAsync(r => r.Id == roomId && r.PropertyId == propertyId, cancellationToken);

        return room is not null
            ? room
            : Result.Failure<DataModels.Room>($"Room with id {roomId} not found");
    }


    private readonly KomoroContext _komoroContext;
}
