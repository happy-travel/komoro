namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

public record LengthsOfStay
{
    public List<LengthOfStay> LengthOfStays { get; init; } = null!;
}
