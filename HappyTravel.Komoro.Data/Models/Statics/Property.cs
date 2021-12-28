﻿using NetTopologySuite.Geometries;

namespace HappyTravel.Komoro.Data.Models.Statics;

public class Property
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Address Address { get; set; } = null!;
    public Point Coordinates { get; set; } = null!;
    public string Phone { get; set; } = string.Empty;
    public int StarRating { get; set; }
    public Contact PrimaryContact { get; set; } = null!;
    public string ReservationEmail { get; set; } = string.Empty;
    public TimeSpan CheckInTime { get; set; }
    public TimeSpan CheckOutTime { get; set; }
    public PassengerAge PassengerAge { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Modified { get; set; }
}