using CSharpFunctionalExtensions;
using HappyTravel.Komoro.Api.Models;
using HappyTravel.Komoro.Data;

namespace HappyTravel.Komoro.Api.Services;

public class PropertyService : IPropertyService
{
    public PropertyService(KomoroContext komoroContext)
    {
        _komoroContext = komoroContext;
    }


    public async Task<List<SlimProperty>> Get(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public async Task<Result<Property>> Get(int propertyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<Result> Add(Property richProperty, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<Result> Modify(int propertyId, Property richProperty, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<Result> Remove(int propertyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    private readonly KomoroContext _komoroContext;
}
