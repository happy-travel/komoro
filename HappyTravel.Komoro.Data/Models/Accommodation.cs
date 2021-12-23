namespace HappyTravel.Komoro.Data.Models;

public class Accommodation
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Modified { get; set; }
}
