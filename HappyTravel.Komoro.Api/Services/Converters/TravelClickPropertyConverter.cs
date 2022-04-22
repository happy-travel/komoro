using HappyTravel.Geography;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Statics;
using HappyTravel.KomoroContracts.Enums;
using HappyTravel.KomoroContracts.Statics;
using HappyTravel.Money.Enums;
using HappyTravel.Money.Models;
using System.Text.RegularExpressions;
using ApiModels = HappyTravel.KomoroContracts.Statics;
using CsvModels = HappyTravel.Komoro.Api.Models.TravelClickCsv;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Services.Converters;

public class TravelClickPropertyConverter
{
    internal static ApiModels.Property Convert(int propertyId, List<CsvModels.PropertyItem> propertyItems, List<DataModels.Country> countries)
    {
        var property = new ApiModels.Property
        {
            Id = propertyId,
            Code = string.Empty,
            SupplierCode = TravelClickCode,
            Name = propertyItems.SingleOrDefault(pi => pi.Key == "Property Name")?.Value.Trim() ?? string.Empty,
            Address = new Address
            {
                Street = propertyItems.SingleOrDefault(pi => pi.Key == "Street Address")?.Value.Trim() ?? string.Empty,
                City = propertyItems.SingleOrDefault(pi => pi.Key == "City")?.Value.Trim() ?? string.Empty,
                PostalCode = propertyItems.SingleOrDefault(pi => pi.Key == "Postal Code")?.Value.Trim() ?? string.Empty,
                Country = GetCountry(propertyItems.SingleOrDefault(pi => pi.Key == "Country")?.Value ?? string.Empty, countries)
            },
            Coordinates = GetCoordinates(propertyItems),
            Phone = propertyItems.SingleOrDefault(pi => pi.Key == "Property Phone")?.Value.Trim() ?? string.Empty,
            StarRating = GetStarRating(propertyItems.SingleOrDefault(pi => pi.Key == "Star Rating")?.Value.Trim() ?? string.Empty),
            PrimaryContact = new ApiModels.Contact
            {
                Name = propertyItems.SingleOrDefault(pi => pi.Key == "Contact Name")?.Value.Trim() ?? string.Empty,
                Title = propertyItems.SingleOrDefault(pi => pi.Key == "Contact Title")?.Value.Trim() ?? string.Empty,
                Email = propertyItems.SingleOrDefault(pi => pi.Key == "Contact Email")?.Value.Trim() ?? string.Empty
            },
            ReservationEmail = propertyItems.SingleOrDefault(pi => pi.Key == "Reservation Email")?.Value.Trim() ?? string.Empty,
            CheckInTime = GetTime(propertyItems.SingleOrDefault(pi => pi.Key == "Check-In Time")?.Value.Trim() ?? string.Empty),
            CheckOutTime = GetTime(propertyItems.SingleOrDefault(pi => pi.Key == "Check-Out Time")?.Value.Trim() ?? string.Empty),
            PassengerAge = new ApiModels.PassengerAge
            {
                InfantFrom = GetAgeFrom(propertyItems.SingleOrDefault(pi => pi.Key == "Infant")?.Value.Trim() ?? string.Empty),
                ChildFrom = GetAgeFrom(propertyItems.SingleOrDefault(pi => pi.Key == "Child")?.Value.Trim() ?? string.Empty),
                AdultFrom = GetAgeFrom(propertyItems.SingleOrDefault(pi => pi.Key == "Adult")?.Value.Trim() ?? string.Empty)
            }
        };

        return property;
    }


    internal static List<ApiModels.Room> Convert(List<CsvModels.Room> roomRecords, List<DataModels.RoomType> roomTypes, List<DataModels.MealPlan> mealPlans)
    {
        var rooms = new List<ApiModels.Room>(roomRecords.Count);
        foreach (var roomRecord in roomRecords)
        {
            var room = new ApiModels.Room
            {
                RoomType = roomTypes.SingleOrDefault(rt => rt.Name == roomRecord.RoomType.Trim())?.ToApiRoomType() ?? new(),
                StandardMealPlan = GetMealPlan(roomRecord.StandardMealPlan, mealPlans),
                StandardOccupancy = GetStandardOccupancy(roomRecord.StandardOccupancy),
                MaximumOccupancy = GetMaximumOccupancy(roomRecord.MaximumOccupancy),
                ExtraAdultSupplement = GetSupplement(roomRecord.ExtraAdultSupplement),
                ChildSupplement = GetSupplement(roomRecord.ChildSupplement),
                InfantSupplement = GetSupplement(roomRecord.InfantSupplement),
                RatePlans = GetRatePlans(roomRecord)
            };
            rooms.Add(room);
        }

        return rooms;
    }


    private static ApiModels.Country GetCountry(string countryString, List<DataModels.Country> countries)
    {
        var country = countryString.Trim();

        return countries.SingleOrDefault(c => c.Name == country)?.ToApiCountry() ?? new();
    }


    private static ApiModels.MealPlan GetMealPlan(string mealPlanString, List<DataModels.MealPlan> mealPlans)
    {
        var mealPlan = mealPlanString.Trim();
        if (mealPlan == "Breakfast")
            mealPlan = "Bed & Breakfast";

        return mealPlans.SingleOrDefault(mp => mp.Name == mealPlan)?.ToApiMealPlan() ?? new();
    }


    private static GeoPoint GetCoordinates(List<CsvModels.PropertyItem> propertyItems)
    {
        var latitudeString = propertyItems.SingleOrDefault(pi => pi.Key == "Latitude")?.Value;
        var longitudeString = propertyItems.SingleOrDefault(pi => pi.Key == "Longitude")?.Value;

        if (!double.TryParse(latitudeString, out double latitude) || !double.TryParse(longitudeString, out double longitude))
            return new GeoPoint(0.0, 0.0);

        return new GeoPoint(longitude, latitude);
    }


    private static int GetStarRating(string starRatingString)
    {
        _ = int.TryParse(starRatingString, out int starRating);

        return starRating;
    }


    private static TimeSpan GetTime(string timeString)
    {
        if (!TimeSpan.TryParse(timeString.AsSpan(0, 5), out var time))
            return TimeSpan.Zero;

        return time;
    }


    private static int GetAgeFrom(string ageString)
    {
        var numberDigits = 0;
        for (int i = 0; i < ageString.Length; i++)
        {
            if (!char.IsDigit(ageString[i]))
                break;
            numberDigits++;
        }
        _ = int.TryParse(ageString.AsSpan(0, numberDigits), out int age);

        return age;
    }


    private static Occupancy GetStandardOccupancy(string occupancy)
    {
        return occupancy.ToLowerInvariant() switch
        {
            "2 adults" => new() { Adults = 2, Children = 0 },
            _ => new()
        };
    }


    private static List<Occupancy> GetMaximumOccupancy(string occupancy)
    {
        return occupancy.Trim().Replace("  ", " ").ToLowerInvariant() switch
        {
            "2 adults" => new() { new() { Adults = 2, Children = 0 } },
            "2 adults and 1 child" => new() { new() { Adults = 2, Children = 1 } },
            "2 adults + 1 child under 12 y.o." => new() { new() { Adults = 2, Children = 1 } },
            "2 adults and 2 child" => new() { new() { Adults = 2, Children = 2 } },
            "2 adults + 2 child under 12 y.o." => new() { new() { Adults = 2, Children = 2 } },
            "3 adults or / 2 adults and 1 child" => new() { new() { Adults = 3, Children = 0 }, new() { Adults = 2, Children = 1 } },
            "3 adults /or 2 adults + 1 child under 12 y.o" => new() { new() { Adults = 3, Children = 0 }, new() { Adults = 2, Children = 1 } },
            "3 adults or / 2 adults + 1 child" => new() { new() { Adults = 3, Children = 0 }, new() { Adults = 2, Children = 1 } },
            "3 adults / or 2 + 1 child under 12 y.o." => new() { new() { Adults = 3, Children = 0 }, new() { Adults = 2, Children = 1 } },
            "3 adults /or 2 adults + 2 children under 12 y.o" => new() { new() { Adults = 3, Children = 0 }, new() { Adults = 2, Children = 2 } },
            "3 adults / or 3 + 1 child under 12 y.o." => new() { new() { Adults = 3, Children = 0 }, new() { Adults = 3, Children = 1 } },
            "3 adults or / 3 adults and 1 child" => new() { new() { Adults = 3, Children = 0 }, new() { Adults = 3, Children = 1 } },
            "3 adults + 1 child" => new() { new() { Adults = 3, Children = 1 } },
            "3 adults and 1 child" => new() { new() { Adults = 3, Children = 1 } },
            "3 adults and 1 child under 12 y.o." => new() { new() { Adults = 3, Children = 1 } },
            "3 adults + 1 child under 12 y.o." => new() { new() { Adults = 3, Children = 1 } },
            "4 adults + 1 child" => new() { new() { Adults = 4, Children = 1 } },
            "4 adults + 1 child under 12 y.o." => new() { new() { Adults = 4, Children = 1 } },
            "6 adults + 1 child" => new() { new() { Adults = 6, Children = 1 } },
            "6 adults + 1 child under 12 y.o." => new() { new() { Adults = 6, Children = 1 } },
            _ => new()
        };
    }


    private static MoneyAmount? GetSupplement(string supplement)
    {
        if (supplement == "NA")
            return null;
        
        if (supplement == "Free")
            return new MoneyAmount(0m, Currencies.USD);

        supplement = Regex.Replace(supplement, @"[^\d]", "", RegexOptions.Compiled);
        _ = decimal.TryParse(supplement, out decimal amount);

        return new(amount, Currencies.USD);
    }


    private static RatePlans GetRatePlans(CsvModels.Room roomRecord)
    {
        var ratePlans = RatePlans.None;

        if (roomRecord.StandardRO == "YES")
            ratePlans |= RatePlans.StandardRO;

        if (roomRecord.StandardBB == "YES")
            ratePlans |= RatePlans.StandardBB;

        if (roomRecord.StaySaveRO == "YES")
            ratePlans |= RatePlans.StaySaveRO;

        if (roomRecord.StaySaveBB == "YES")
            ratePlans |= RatePlans.StaySaveBB;

        if (roomRecord.EarlyBirdRO == "YES")
            ratePlans |= RatePlans.EarlyBirdRO;

        if (roomRecord.EarlyBirdBB == "YES")
            ratePlans |= RatePlans.EarlyBirdBB;

        if (roomRecord.SpecialDealRO == "YES")
            ratePlans |= RatePlans.SpecialDealRO;

        if (roomRecord.SpecialDealBB == "YES")
            ratePlans |= RatePlans.SpecialDealBB;

        return ratePlans;
    }


    private const string TravelClickCode = "travelClick";
}
