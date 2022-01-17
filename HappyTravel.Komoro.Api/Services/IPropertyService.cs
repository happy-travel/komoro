using CSharpFunctionalExtensions;
using HappyTravel.Komoro.Api.Models;

namespace HappyTravel.Komoro.Api.Services;

public interface IPropertyService
{
    Task<List<SlimProperty>> Get(CancellationToken cancellationToken);
    Task<Result<Property>> Get(int accommodationId, CancellationToken cancellationToken);
    Task<Result> Add(Property richAaccommodation, CancellationToken cancellationToken);
    Task<Result> Modify(int accommodationId, Property richAaccommodation, CancellationToken cancellationToken);
    Task<Result> Remove(int accommodationId, CancellationToken cancellationToken);
}
