using ApiModels = HappyTravel.KomoroContracts.Statics;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;

public static class PropertyExtension
{
    public static ApiModels.SlimProperty ToSlimProperty(this DataModels.Property property)
    {
        return new ApiModels.SlimProperty
        {
            Id = property.Id,
            SupplierId = property.SupplierId,
            Name = property.Name,
            Address = property.Address.ToApiAddress(property.Country),
            Coordinates = new Geography.GeoPoint(property.Coordinates),
            Phone = property.Phone,
            StarRating = property.StarRating,
            PrimaryContact = property.PrimaryContact,
            ReservationEmail = property.ReservationEmail,
            CheckInTime = property.CheckInTime,
            CheckOutTime = property.CheckOutTime,
            PassengerAge = property.PassengerAge
        };
    }


    public static ApiModels.Property ToApiProperty(this DataModels.Property property)
    {
        return new ApiModels.Property
        {
            Id = property.Id,
            SupplierId = property.SupplierId,
            Name = property.Name,
            Address = property.Address.ToApiAddress(property.Country),
            Coordinates = new Geography.GeoPoint(property.Coordinates),
            Phone = property.Phone,
            StarRating = property.StarRating,
            PrimaryContact = property.PrimaryContact,
            ReservationEmail = property.ReservationEmail,
            CheckInTime = property.CheckInTime,
            CheckOutTime = property.CheckOutTime,
            PassengerAge = property.PassengerAge,
            Rooms = property.Rooms.Select(r => r.ToApiRoom()).ToList(),
            CancellationPolicies = property.CancellationPolicies.Select(cp => cp.ToApiCancellationPolicy()).ToList()
        };
    }
}
