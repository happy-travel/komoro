using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.TravelClickChannelManager.Models;
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
            Success = new Success(),
            EchoData = otaPingRQ.EchoData
            /*Errors = new List<Error> 
            { 
                new Error
                {
                    Type = Models.Enums.ErrorWarningTypes.Authentication,
                    Code = Models.Enums.ErrorCodes.ServiceRestrictionSecurity,
                    ShortText = "Service restriction - security",
                    ErrorText = "The supplied credentials are invalid or do not have access to hotel 'HOTEL001'",
                }
            }*/
        };
    }


    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
}
