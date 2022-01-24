using CSharpFunctionalExtensions;
using FluentValidation;
using HappyTravel.Komoro.Api.Infrastructure;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;
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
        return await _komoroContext.Properties.Select(p => p.ToSlimProperty())
            .ToListAsync(cancellationToken);
    }


    public async Task<Result<ApiModels.Property>> Get(int propertyId, CancellationToken cancellationToken)
    {
        var property = await _komoroContext.Properties.Include(p => p.Rooms).ThenInclude(r => r.RoomType)
            .Include(p => p.Rooms).ThenInclude(r => r.MealPlan)
            .Include(p => p.CancellationPolicies)
            .SingleOrDefaultAsync(p => p.Id == propertyId, cancellationToken);

        return property is not null
            ? property.ToApiProperty()
            : Result.Failure<ApiModels.Property>($"Property with id {propertyId} not found");
    }


    public async Task<Result> Add(ApiModels.Property apiProperty, CancellationToken cancellationToken)
    {
        return await Validate(apiProperty)
            .Tap(Add);


        async Task Add()
        {
            var property = new DataModels.Property
            {
                SupplierId = apiProperty.SupplierId,
                Name = apiProperty.Name,
                Address = apiProperty.Address,
                Coordinates = apiProperty.Coordinates,
                Phone = apiProperty.Phone,
                StarRating = apiProperty.StarRating,
                PrimaryContact = apiProperty.PrimaryContact,
                ReservationEmail = apiProperty.ReservationEmail,
                CheckInTime = apiProperty.CheckInTime,
                CheckOutTime = apiProperty.CheckOutTime,
                PassengerAge = apiProperty.PassengerAge,
                Created = DateTimeOffset.UtcNow
            };

            _komoroContext.Properties.Add(property);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Modify(int propertyId, ApiModels.Property apiProperty, CancellationToken cancellationToken)
    {
        return await Validate(apiProperty)
            .Bind(() => GetProperty(propertyId, cancellationToken))
            .Tap(Update);

        async Task Update(DataModels.Property property)
        {
            property.SupplierId = apiProperty.SupplierId;
            property.Name = apiProperty.Name;
            property.Address = apiProperty.Address;
            property.Coordinates = apiProperty.Coordinates;
            property.Phone = apiProperty.Phone;
            property.StarRating = apiProperty.StarRating;
            property.PrimaryContact = apiProperty.PrimaryContact;
            property.ReservationEmail = apiProperty.ReservationEmail;
            property.CheckInTime = apiProperty.CheckInTime;
            property.CheckOutTime = apiProperty.CheckOutTime;
            property.PassengerAge = apiProperty.PassengerAge;
            property.Modified = DateTimeOffset.UtcNow;

            _komoroContext.Properties.Update(property);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Remove(int propertyId, CancellationToken cancellationToken)
    {
        return await GetProperty(propertyId, cancellationToken)
            .Tap(Remove);


        async Task Remove(DataModels.Property property)
        {
            _komoroContext.Properties.Remove(property);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    private static Result Validate(ApiModels.Property property)
        => GenericValidator<ApiModels.Property>.Validate(v =>
        {
            v.RuleFor(p => p.SupplierId).NotEmpty();
            v.RuleFor(p => p.Name).NotEmpty();
            v.RuleFor(p => p.Address).NotEmpty();
            v.RuleFor(p => p.Coordinates).NotEmpty();
            v.RuleFor(p => p.Phone).NotEmpty();
            v.RuleFor(p => p.PrimaryContact).NotEmpty();
            v.RuleFor(p => p.ReservationEmail).NotEmpty();
            v.RuleFor(p => p.CheckInTime).NotEmpty();
            v.RuleFor(p => p.CheckOutTime).NotEmpty();
            v.RuleFor(p => p.PassengerAge).NotEmpty();
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
