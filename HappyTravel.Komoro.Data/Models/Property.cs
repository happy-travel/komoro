﻿namespace HappyTravel.Komoro.Data.Models;

public class Property
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Address Address { get; set; } = null!;
    public object Coordinates { get; set; } = null!; // GeoPoint
    public string Phone { get; set; } = string.Empty;
    public string StarRating { get; set; } = string.Empty;
    public Contact PrimaryContact { get; set; } = null!;
    public string ReservationEmail { get; set; } = string.Empty;
    public TimeSpan CheckInTime { get; set; }
    public TimeSpan CheckOutTime { get; set; }
    public PassengerAge PassengerAge { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Modified { get; set; }
}
