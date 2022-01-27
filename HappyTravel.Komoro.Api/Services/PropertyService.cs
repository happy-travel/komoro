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
using HappyTravel.Komoro.Api.Services.Converters;

namespace HappyTravel.Komoro.Api.Services;

public class PropertyService : IPropertyService
{
    public PropertyService(KomoroContext komoroContext, IRoomService roomService)
    {
        _komoroContext = komoroContext;
        _roomService = roomService;
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
            .Ensure(() => PropertyHasNoDuplicates(apiProperty), "Adding property has duplicate")
            .Tap(Add);


        async Task<bool> PropertyHasNoDuplicates(ApiModels.Property property)
            => !await _komoroContext.Properties.Where(p => p.Name == property.Name)
                .AnyAsync(cancellationToken);


        async Task Add()
        {
            var utcNow = DateTimeOffset.UtcNow;
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
                Created = utcNow,
                Modified = utcNow
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


    public async Task<Result> UploadTravelClickProperty(int propertyId, IFormFile uploadedFile, CancellationToken cancellationToken)
    {
        return await UploadData()
            .Map(Convert)
            .Ensure(PropertyHasNoDuplicates, "Uploading property has duplicate")
            .Check(ValidateProperty)
            .Map(AddOrModifyProperty)
            .Bind(AddOrUpdateRooms)
            .Bind(RemoveRooms);


        Result<(List<CsvModels.PropertyItem>, List<CsvModels.Room>)> UploadData()
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
                    propertyItemRecords.Add(propertyItemRecord);
                }
            }

            if (propertyItemRecords.Count < 18)
                return Result.Failure<(List<CsvModels.PropertyItem>, List<CsvModels.Room>)>("Property data loaded from CSV file is incomplete");

            if (roomRecords.Count == 0)
                return Result.Failure<(List<CsvModels.PropertyItem>, List<CsvModels.Room>)>("No rooms were found in the hotel when loading the CSV file");

            return (propertyItemRecords, roomRecords);
        }


        async Task<(ApiModels.Property, List<ApiModels.Room>)> Convert((List<CsvModels.PropertyItem> propertyItems, List<CsvModels.Room> rooms) data)
        {
            var roomTypes = await _komoroContext.RoomTypes.ToListAsync(cancellationToken);
            var mealPlans = await _komoroContext.MealPlans.ToListAsync(cancellationToken);

            var property = TravelClickConverter.Convert(propertyId, data.propertyItems);
            var rooms = TravelClickConverter.Convert(data.rooms, roomTypes, mealPlans);
            
            return (property, rooms);
        }


        async Task<bool> PropertyHasNoDuplicates((ApiModels.Property property, List<ApiModels.Room> rooms) data)
            => !await _komoroContext.Properties.Where(p => p.Id != propertyId && p.Name == data.property.Name)
                .AnyAsync(cancellationToken);


        static Result ValidateProperty((ApiModels.Property property, List<ApiModels.Room> rooms) data)
            => Validate(data.property);


        async Task<(int porpertyId, List<ApiModels.Room>)> AddOrModifyProperty((ApiModels.Property property, List<ApiModels.Room> rooms) data)
        {
            var apiProperty = data.property;
            var property = await _komoroContext.Properties.SingleOrDefaultAsync(p => p.Id == propertyId, cancellationToken);
            if (property is null)
            {
                var utcNow = DateTimeOffset.UtcNow;
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
                    Created = utcNow,
                    Modified = utcNow
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

            return (property.Id, data.rooms);
        }


        async Task<Result<(int, List<int>)>> AddOrUpdateRooms((int propertyId, List<ApiModels.Room> rooms) data)
        {
            var existingRooms = await _roomService.Get(data.propertyId, cancellationToken);

            foreach (var room in data.rooms)
            {
                var existingRoom = existingRooms.SingleOrDefault(r => r.RoomType.Id == room.RoomType.Id);
                if (existingRoom is null)
                {
                    var (_, isFailure, error) = await _roomService.Add(data.propertyId, room, cancellationToken);
                    if (isFailure)
                        return Result.Failure<(int, List<int>)>(error);
                }
                else
                {
                    var (_, isFailure, error) = await _roomService.Modify(data.propertyId, existingRoom.Id, room, cancellationToken);
                    if (isFailure)
                        return Result.Failure<(int, List<int>)>(error);

                    existingRooms.Remove(existingRoom);
                }
            }

            return (data.propertyId, existingRooms.Select(r => r.Id).ToList());
        }


        async Task<Result> RemoveRooms((int propertyId, List<int> roomIds) data)
        {
            foreach(var roomId in data.roomIds)
            {
                var (_, isFailure, error) = await _roomService.Remove(data.propertyId, roomId, cancellationToken);
                if (!isFailure)
                    return Result.Failure(error);
            }

            return Result.Success();
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
    private readonly IRoomService _roomService;
}
