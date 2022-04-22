using HappyTravel.Komoro.Common.Infrastructure.Extensions;
using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;

namespace HappyTravel.Komoro.TravelClickChannelManager.Infrastructure;

public static class ErrorHelper
{
    public static Error GetError(ErrorWarningTypes errorWarningType, ErrorCodes errorCode, string? EntityCode)
    {
        return new Error
        {
            Type = errorWarningType,
            Code = errorCode,
            ShortText = errorCode.GetEnumMember(),
            ErrorText = string.IsNullOrEmpty(EntityCode) 
                ? errorCode.GetDescription() 
                : $"{errorCode.GetDescription()}: {EntityCode}"
        };
    }
}
