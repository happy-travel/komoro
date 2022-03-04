namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Requests;

public record ProfileInfo
{
    public Profile Profile { get; set; } = new();
}
