using CSharpFunctionalExtensions;
using HappyTravel.Komoro.Api.Infrastructure;
using HappyTravel.Komoro.Data;
using Microsoft.EntityFrameworkCore;
using ApiModels = HappyTravel.Komoro.Api.Models;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Services;

public class PropertyService : IPropertyService
{
    public PropertyService(KomoroContext komoroContext)
    {
        _komoroContext = komoroContext;
    }


    public async Task<List<ApiModels.SlimProperty>> Get(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<ApiModels.Property>> Get(int propertyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<Result> Add(ApiModels.Property richProperty, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<Result> Modify(int propertyId, ApiModels.Property property, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<Result> Remove(int propertyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private static Result Validate(ApiModels.Property property)
        => GenericValidator<ApiModels.Property>.Validate(v =>
        {
            /*v.RuleFor(r => r.PropertyId).NotEmpty();
            v.RuleFor(r => r.RoomType).NotEmpty();
            v.RuleFor(r => r.StandardMealPlan).NotEmpty();
            v.RuleFor(r => r.StandardOccupancy).NotEmpty();
            v.RuleFor(r => r.MaximumOccupancy).NotEmpty();
            v.RuleFor(r => r.ExtraAdultSupplement).NotEmpty();
            v.RuleFor(r => r.ChildSupplement).NotEmpty();
            v.RuleFor(r => r.InfantSupplement).NotEmpty();
            v.RuleFor(r => r.RatePlans).NotEmpty();*/
        },
        property);


    private async Task<Result<DataModels.Property>> GetProperty(int propertyId, CancellationToken cancellationToken)
    {
        var property = await _komoroContext.Properties.SingleOrDefaultAsync(p => p.Id == propertyId, cancellationToken);

        return property is not null
            ? property
            : Result.Failure<DataModels.Property>($"Property with id {propertyId} not found");
    }


    private readonly KomoroContext _komoroContext;
}
