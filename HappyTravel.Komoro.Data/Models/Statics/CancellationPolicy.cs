namespace HappyTravel.Komoro.Data.Models.Statics
{
    public class CancellationPolicy
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public string? SeasonalityOrEvent { get; set; }
        public int Deadline { get; set; }
        public NoShowPolicies NoShow { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? Modified { get; set; }
    }
}
