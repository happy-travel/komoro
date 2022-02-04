using System.ComponentModel.DataAnnotations;

namespace HappyTravel.Komoro.Data.Models.Statics;

public class Country
{
    public int Id { get; set; }

    [MaxLength(2)]
    public string Alpha2Code { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset Modified { get; set; }
}
