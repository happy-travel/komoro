namespace HappyTravel.Komoro.Data.Models.Availabilities;

public class AvailabilityRestriction
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int PropertyId { get; set; }
    public int RoomTypeId { get; set; }
    public string RatePlanCode { get; set; } = string.Empty;
    public RestrictionTypes Restriction { get; set; }
    public RestrictionStatuses Status { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Modified { get; set; }
}
