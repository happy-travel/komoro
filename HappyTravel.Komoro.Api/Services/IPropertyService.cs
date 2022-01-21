using CSharpFunctionalExtensions;
using HappyTravel.Komoro.Api.Models;

namespace HappyTravel.Komoro.Api.Services;

public interface IPropertyService
{
    Task<List<SlimProperty>> Get(CancellationToken cancellationToken);
    Task<Result<Property>> Get(int propertyId, CancellationToken cancellationToken);
    Task<Result> Add(Property property, CancellationToken cancellationToken);
    Task<Result> Modify(int propertyId, Property property, CancellationToken cancellationToken);
    Task<Result> Remove(int propertyId, CancellationToken cancellationToken);
    Task<Result<string>> UploadTravelClickProperty(IFormFile uploadedFile, CancellationToken cancellationToken);
}
