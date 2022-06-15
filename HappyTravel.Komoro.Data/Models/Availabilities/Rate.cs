using HappyTravel.Komoro.Data.Models.Statics;
using HappyTravel.KomoroContracts.Availabilities;
using HappyTravel.Money.Enums;

namespace HappyTravel.Komoro.Data.Models.Availabilities;

public class Rate
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int PropertyId { get; set; }
    public int RoomTypeId { get; set; }
    public string RatePlanCode { get; set; } = string.Empty;
    public Currencies Currency { get; set; }
    public List<BaseRate>? BaseRates { get; set; }
    public List<AdditionalRate>? AdditionalRates { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Modified { get; set; }

    public Property Property { get; set; } = null!;
    public RoomType RoomType { get; set; } = null!;
}
