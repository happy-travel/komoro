namespace HappyTravel.Komoro.Api.Infrastructure.Options;

public class AuthorityOptions
{
    public string? AuthorityUrl { get; set; }
    public string? Audience { get; set; }
    public TimeSpan AutomaticRefreshInterval { get; set; }
}