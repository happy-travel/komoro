using HappyTravel.Komoro.Data.Models.Availabilities;
using NetTopologySuite.Geometries;
using ApiModels = HappyTravel.KomoroContracts.Statics;

namespace HappyTravel.Komoro.Data.Models.Statics;

public class Property
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string SupplierCode { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Address Address { get; set; } = null!;
    public Point Coordinates { get; set; } = null!;
    public string Phone { get; set; } = string.Empty;
    public int StarRating { get; set; }
    public ApiModels.Contact PrimaryContact { get; set; } = null!;
    public string ReservationEmail { get; set; } = string.Empty;
    public TimeSpan CheckInTime { get; set; }
    public TimeSpan CheckOutTime { get; set; }
    public ApiModels.PassengerAge PassengerAge { get; set; } = null!;
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset Modified { get; set; }

    public List<Room> Rooms { get; set; } = new();
    public List<CancellationPolicy> CancellationPolicies { get; set; } = new();
    public List<AvailabilityRestriction> AvailabilityRestrictions { get; set; } = new();
    public Country Country { get; set; } = null!;
}
