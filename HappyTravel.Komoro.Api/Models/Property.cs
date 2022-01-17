using HappyTravel.Komoro.Data.Models.Statics;
using NetTopologySuite.Geometries;

namespace HappyTravel.Komoro.Api.Models;

public record Property
{
    public int Id { get; init; }
    public int SupplierId { get; init; }
    public string Name { get; init; } = string.Empty;
    public Address Address { get; init; } = null!;
    public Point Coordinates { get; init; } = null!;
    public string Phone { get; init; } = string.Empty;
    public int StarRating { get; init; }
    public Contact PrimaryContact { get; init; } = null!;
    public string ReservationEmail { get; init; } = string.Empty;
    public TimeSpan CheckInTime { get; init; }
    public TimeSpan CheckOutTime { get; init; }
    public PassengerAge PassengerAge { get; init; } = null!;
}
