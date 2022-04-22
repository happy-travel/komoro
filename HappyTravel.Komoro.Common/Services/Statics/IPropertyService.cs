using CSharpFunctionalExtensions;
using HappyTravel.KomoroContracts.Statics;
using Microsoft.AspNetCore.Http;

namespace HappyTravel.Komoro.Common.Services.Statics;

public interface IPropertyService
{
    Task<List<SlimProperty>> Get(string supplierCode, int skip, int top, DateTime? modificationDate, CancellationToken cancellationToken);
    Task<List<SlimProperty>> Get(CancellationToken cancellationToken);
    Task<Result<Property>> Get(int propertyId, CancellationToken cancellationToken);
    Task<int> GetId(string supplierCode, string propertyCode);
    Task<bool> IsExist(string supplierCode, string propertyCode);
    Task<Result> Add(Property property, CancellationToken cancellationToken);
    Task<Result> Modify(int propertyId, Property property, CancellationToken cancellationToken);
    Task<Result> Remove(int propertyId, CancellationToken cancellationToken);
    Task<Result> UploadTravelClickProperty(int propertyId, IFormFile uploadedFile, CancellationToken cancellationToken);
}
