using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Ping;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public class PingService : IPingService
{
    public PingService(IDateTimeOffsetProvider dateTimeOffsetProvider)
    {
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
    }


    public OtaPingRS Ping(OtaPingRQ otaPingRQ)
    {
        return new OtaPingRS
        {
            Version = otaPingRQ.Version,
            TimeStamp = _dateTimeOffsetProvider.UtcNow(),
            Success = new Models.Success(),
            EchoData = otaPingRQ.EchoData
        };
    }


    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
}
