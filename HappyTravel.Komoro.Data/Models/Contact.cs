namespace HappyTravel.Komoro.Data.Models;

public class Contact
{
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Description { get; set; }
}
