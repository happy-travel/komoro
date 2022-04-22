using CSharpFunctionalExtensions;
using HappyTravel.KomoroContracts.Statics;
using Microsoft.AspNetCore.Http;

namespace HappyTravel.Komoro.Common.Services.Statics;

public interface IPropertyService
{
    Task<List<SlimProperty>> Get(int supplierId, int skip, int top, DateTime? modificationDate, CancellationToken cancellationToken);
    Task<List<SlimProperty>> Get(CancellationToken cancellationToken);
    Task<Result<Property>> Get(int propertyId, CancellationToken cancellationToken);
    Task<int> GetId(int supplierId, string propertyCode);
    Task<bool> IfExist(int supplierId, string propertyCode);
    Task<Result> Add(Property property, CancellationToken cancellationToken);
    Task<Result> Modify(int propertyId, Property property, CancellationToken cancellationToken);
    Task<Result> Remove(int propertyId, CancellationToken cancellationToken);
    Task<Result> UploadTravelClickProperty(int propertyId, IFormFile uploadedFile, CancellationToken cancellationToken);
}
