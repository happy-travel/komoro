namespace HappyTravel.Komoro.TravelLineChannelManager.Models;

/// <summary>
/// Type of accommodation in the room (single, double, etc.)
/// </summary>
internal record Occupancy
{
    /// <summary>
    /// The unique identifier for the placement type
    /// </summary>
    public string Code { get; init; } = string.Empty;

    /// <summary>
    /// Placement type. Can take one of the set values:
    /// • adultBed - accommodation of an adult in the main place.
    /// • adultExtraBed – accommodation of an adult on extra bed.place.
    /// • childBandBed - placement of the child in the main place.
    /// • childBandExtraBed – placement of a child in an extra bed.
    /// • childBandWithoutBed - placing an infant without a seat.
    /// Optional parameter: if the parameter is omitted, then the default placement type is adultBed.
    /// </summary>
    public BedTypes BedType { get; init; }

    /// <summary>
    /// Number of adults for the type of accommodation "adultBed". For other placement types, the element is missing.
    /// </summary>
    public int? PersonQuantity { get; init; }

    /// <summary>
    /// Minimum allowable age when staying in an extra bed (optional parameter)
    /// </summary>
    public int? MinAge { get; init; }

    /// <summary>
    /// Maximum allowable age when staying in an extra bed (optional parameter)
    /// </summary>
    public int? MaxAge { get; init; }

    /// <summary>
    /// Text description in free form. For example, "a place for children only" (optional).
    /// If the parameter is omitted, the description is automatically generated based on the characteristics of the accommodation type 
    /// (minAge, maxAge, bedType, personQuantity).
    /// </summary>
    public string? Name { get; init; }
}
