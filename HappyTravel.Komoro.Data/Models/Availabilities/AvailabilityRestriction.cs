using HappyTravel.Komoro.Data.Models.Statics;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.Data.Models.Availabilities;

public class AvailabilityRestriction
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int PropertyId { get; set; }
    public int RoomTypeId { get; set; }
    public string RatePlanCode { get; set; } = string.Empty;
    public RestrictionStatusDetails? RestrictionStatusDetails { get; set; }
    public StayDurationDetails? StayDurationDetails { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Modified { get; set; }

    public Property Property { get; set; } = null!;
    public RoomType RoomType { get; set; } = null!;
}
