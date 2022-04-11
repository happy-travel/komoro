using HappyTravel.Komoro.Data.Models.Statics;
using HappyTravel.KomoroContracts.Enums;

namespace HappyTravel.Komoro.Data.Models.Availabilities;

public class AvailabilityRestriction
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int PropertyId { get; set; }
    public int RoomTypeId { get; set; }
    public string RatePlanCode { get; set; } = string.Empty;
    public RestrictionTypes? Restriction { get; set; }
    public RestrictionStatuses? Status { get; set; }
    public int? MinAdvancedBookingOffset { get; init; }
    public bool? IsLengthOfStayArrivalDateBased { get; init; }
    public int? LengthOfStayMinimumDays { get; init; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Modified { get; set; }

    public Property Property { get; set; } = null!;
    public RoomType RoomType { get; set; } = null!;
}
