using HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Models
{
    public record CancellationPolicy
    {
        public int Id { get; init; }
        public int PropertyId { get; init; }
        public DateOnly FromDate { get; init; }
        public DateOnly ToDate { get; init; }
        public string? SeasonalityOrEvent { get; init; }
        public int Deadline { get; init; }
        public double Percentage { get; init; }
        public NoShowPolicies NoShow { get; init; }
    }
}
