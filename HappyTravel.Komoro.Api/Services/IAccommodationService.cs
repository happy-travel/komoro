using CSharpFunctionalExtensions;
using HappyTravel.Komoro.Api.Models;

namespace HappyTravel.Komoro.Api.Services;

public interface IAccommodationService
{
    Task<List<SlimAccommodation>> Get(CancellationToken cancellationToken);
    Task<Result<RichAccommodation>> Get(int accommodationId, CancellationToken cancellationToken);
    Task<Result> Add(RichAccommodation richAaccommodation, CancellationToken cancellationToken);
    Task<Result> Modify(int accommodationId, RichAccommodation richAaccommodation, CancellationToken cancellationToken);
    Task<Result> Delete(int accommodationId, CancellationToken cancellationToken);
}
