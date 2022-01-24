using CSharpFunctionalExtensions;
using HappyTravel.Komoro.Api.Models;

namespace HappyTravel.Komoro.Api.Services;

public interface IRoomService
{
    Task<List<Room>> Get(int propertyId, CancellationToken cancellationToken);
    Task<Result> Add(int propertyId, Room room, CancellationToken cancellationToken);
    Task<Result> Modify(int propertyId, int roomId, Room room, CancellationToken cancellationToken);
    Task<Result> Remove(int propertyId, int roomId, CancellationToken cancellationToken);
}
