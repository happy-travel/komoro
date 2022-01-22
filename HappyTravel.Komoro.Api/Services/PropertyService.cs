using CSharpFunctionalExtensions;
using CsvHelper;
using CsvHelper.Configuration;
using FluentValidation;
using HappyTravel.Komoro.Api.Infrastructure;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;
using HappyTravel.Komoro.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ApiModels = HappyTravel.Komoro.Api.Models;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;
using CsvModels = HappyTravel.Komoro.Api.Models.TravelClickCsv;

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


    public Task<Result<string>> UploadTravelClickProperty(IFormFile uploadedFile, CancellationToken cancellationToken)
    {
        return UploadProperty()
            .Bind(Convert)
            .Check(Validate)
            .Map(AddOrModifyProperty);


        Result<(List<CsvModels.PropertyItem>, List<CsvModels.Room>)> UploadProperty()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false
            };
            using var reader = new StreamReader(uploadedFile.OpenReadStream());
            using var csv = new CsvReader(reader, configuration);

            csv.Context.RegisterClassMap<CsvModels.RoomMap>();
            csv.Context.RegisterClassMap<CsvModels.PropertyItemMap>();
            var roomRecords = new List<CsvModels.Room>();
            var propertyItemRecords = new List<CsvModels.PropertyItem>();
            var rowNumber = 0;
            var isRoomData = true;
            while (csv.Read())
            {
                rowNumber++;
                if (rowNumber <= 3)
                    continue;

                if (isRoomData)
                {
                    var roomRecord = csv.GetRecord<CsvModels.Room>();
                    if (string.IsNullOrEmpty(roomRecord.RoomType))
                    {
                        isRoomData = false;
                        continue;
                    }
                    roomRecords.Add(roomRecord);
                }
                else
                {
                    var propertyItemRecord = csv.GetRecord<CsvModels.PropertyItem>();
                    if (string.IsNullOrEmpty(propertyItemRecord.Key))
                        continue;
                }
            }

            if (propertyItemRecords.Count < 18)
                return Result.Failure<(List<CsvModels.PropertyItem>, List<CsvModels.Room>)>("Property data loaded from CSV file is incomplete");

            if (roomRecords.Count == 0)
                return Result.Failure<(List<CsvModels.PropertyItem>, List<CsvModels.Room>)>("No rooms were found in the hotel when loading the CSV file");

            return (propertyItemRecords, roomRecords);
        }


        Result<ApiModels.Property> Convert((List<CsvModels.PropertyItem> propertyItems, List<CsvModels.Room> rooms) data)
        {
            var property = new DataModels.Property();

            foreach (var propertyItem in data.propertyItems)
            {
                switch (propertyItem.Key)
                {
                    case "Property Name":
                        property.Name = propertyItem.Value;
                        break;
                    case "Street Address":
                        property.Address.Street = propertyItem.Value;
                        break;
                    case "City":
                        property.Address.City = propertyItem.Value;
                        break;
                    case "Postal Code":
                        property.Address.PostalCode = propertyItem.Value;
                        break;
                    case "Country":
                        property.Address.Country = propertyItem.Value;
                        break;
                    case "Latitude":
                        _ = double.TryParse(propertyItem.Value, out double latitude);
                        break;
                    case "Longitude":
                        _ = double.TryParse(propertyItem.Value, out double longitude);
                        break;
                    case "Property Phone":
                        property.Phone = propertyItem.Value;
                        break;
                    case "Star Rating":
                        _ = int.TryParse(propertyItem.Value, out int starRating);
                        break;
                    case "Contact Name":
                        property.PrimaryContact.Name = propertyItem.Value;
                        break;
                    case "Contact Title":
                        property.PrimaryContact.Title = propertyItem.Value;
                        break;
                    case "Contact Email":
                        property.PrimaryContact.Email = propertyItem.Value;
                        break;
                    case "Reservation Email":
                        property.ReservationEmail = propertyItem.Value;
                        break;
                    case "Check-In Time":
                        if (!TimeSpan.TryParse(propertyItem.Value.Substring(0, 5), out var checkInTime))
                            return Result.Failure<ApiModels.Property>("Check-in time is in the wrong format");
                        break;
                    case "Check-Out Time":
                        if (!TimeSpan.TryParse(propertyItem.Value.Substring(0, 5), out var checkOutTime))
                            return Result.Failure<ApiModels.Property>("Check-out time is in the wrong format");
                        break;
                    case "Infant":
                        property.PrimaryContact.Email = propertyItem.Value;
                        break;
                    case "Child":
                        property.PrimaryContact.Email = propertyItem.Value;
                        break;
                    case "Adult":
                        property.PrimaryContact.Email = propertyItem.Value;
                        break;
                    default:
                        return Result.Failure<ApiModels.Property>("Property data in CSV file contains an unspecified key");

                }
            }

            return Result.Success(new ApiModels.Property());
        }


        async Task<string> AddOrModifyProperty(ApiModels.Property apiProperty)
        {
            var property = await _komoroContext.Properties.SingleOrDefaultAsync(p => p.Id == apiProperty.Id, cancellationToken);
            if (property is null)
            {
                property = new DataModels.Property
                {
                    Id = apiProperty.Id,
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
            }
            else
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
            }
            await _komoroContext.SaveChangesAsync(cancellationToken);

            return $"Property {property.Name} successfully upoaded from CSV file";
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
