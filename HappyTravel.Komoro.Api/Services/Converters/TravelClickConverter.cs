using CSharpFunctionalExtensions;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;
using HappyTravel.Money.Models;
using NetTopologySuite.Geometries;
using ApiModels = HappyTravel.Komoro.Api.Models;
using CsvModels = HappyTravel.Komoro.Api.Models.TravelClickCsv;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Services.Converters;

public class TravelClickConverter
{
    internal static Result<DataModels.Property> Convert(List<CsvModels.PropertyItem> propertyItems)
    {
        var property = new DataModels.Property();
        var latitude = 0.0;
        var longitude = 0.0;
        foreach (var propertyItem in propertyItems)
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
                    if (!double.TryParse(propertyItem.Value, out latitude))
                        return Result.Failure<DataModels.Property>("Latitude is in the wrong format");
                    break;
                case "Longitude":
                    if (!double.TryParse(propertyItem.Value, out longitude))
                        return Result.Failure<DataModels.Property>("Longitude is in the wrong format");
                    break;
                case "Property Phone":
                    property.Phone = propertyItem.Value;
                    break;
                case "Star Rating":
                    if (!int.TryParse(propertyItem.Value, out int starRating))
                        return Result.Failure<DataModels.Property>("Star rating is in the wrong format");
                    property.StarRating = starRating;
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
                    if (!TimeSpan.TryParse(propertyItem.Value.AsSpan(0, 5), out var checkInTime))
                        return Result.Failure<DataModels.Property>("Check-in time is in the wrong format");
                    property.CheckInTime = checkInTime;
                    break;
                case "Check-Out Time":
                    if (!TimeSpan.TryParse(propertyItem.Value.AsSpan(0, 5), out var checkOutTime))
                        return Result.Failure<DataModels.Property>("Check-out time is in the wrong format");
                    property.CheckOutTime = checkOutTime;
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
                    return Result.Failure<DataModels.Property>("Property data in CSV file contains an unspecified key");
            }
        }
        property.SupplierId = TravelClickId;
        property.Coordinates = new Point(latitude, longitude);

        return property;
    }


    internal Result<List<ApiModels.Room>> Convert(List<CsvModels.Room> roomRecords, List<DataModels.RoomType> roomTypes, List<DataModels.MealPlan> mealPlans)
    {
        var rooms = new List<ApiModels.Room>();
        foreach (var roomRecord in roomRecords)
        {
            var room = new ApiModels.Room
            {
                RoomType = roomTypes.SingleOrDefault(rt => rt.Name == roomRecord.RoomType)?.ToApiRoomType() ?? new(),
                StandardMealPlan = mealPlans.SingleOrDefault(mp => mp.Name == roomRecord.StandardMealPlan)?.ToApiMealPlan() ?? new(),
                StandardOccupancy = GetStandardOccupancy(roomRecord.StandardOccupancy),
                MaximumOccupancy = GetMaximumOccupancy(roomRecord.MaximumOccupancy),
                ExtraAdultSupplement = GetAdultSupplement(roomRecord.ExtraAdultSupplement),
                ChildSupplement = GetSupplement(roomRecord.ChildSupplement),
                InfantSupplement = GetSupplement(roomRecord.InfantSupplement),
                RatePlans = GetRatePlans(roomRecord)
            };
            rooms.Add(room);
        }

        return rooms;
    }


    private static DataModels.Occupancy GetStandardOccupancy(string occupancy)
    {
        return occupancy switch
        {
            "2 adults" => new() { Adults = 2, Children = 0 },
            _ => new()
        };
    }


    private static List<DataModels.Occupancy> GetMaximumOccupancy(string occupancy)
    {
        return occupancy switch
        {
            "2 adults + 1 child under 12 y.o." => new() { new() { Adults = 2, Children = 1 } },
            "3 adults / or 2 + 1  child under 12 y.o." => new() { new() { Adults = 3, Children = 0 }, new() { Adults = 2, Children = 1 } },
            "3 adults + 1 child under 12 y.o." => new() { new() { Adults = 3, Children = 1 } },
            "3 adults / or 3 + 1  child under 12 y.o." => new() { new() { Adults = 3, Children = 0 }, new() { Adults = 3, Children = 1 } },

            _ => new()
        };
    }


    private static MoneyAmount GetAdultSupplement(string supplement)
    {
        return new();
    }


    private static MoneyAmount GetSupplement(string supplement)
    {
        return new();
    }


    private static DataModels.RatePlans GetRatePlans(CsvModels.Room room)
    {
        return DataModels.RatePlans.None;
    }


    private const int TravelClickId = 14;
}
