namespace HappyTravel.Komoro.Common.Infrastructure;

public class DateTimeOffsetProvider : IDateTimeOffsetProvider
{
    public DateTimeOffset UtcNow() => DateTimeOffset.UtcNow;
}
