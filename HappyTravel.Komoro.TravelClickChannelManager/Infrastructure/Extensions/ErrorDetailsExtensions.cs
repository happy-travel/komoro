﻿using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;
using HappyTravel.KomoroContracts;

namespace HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;

public static class ErrorDetailsExtensions
{
    public static Error ToError(this ErrorDetails errorDetails)
    {
        var errorWarningType = errorDetails.ErrorCode switch
        {
            KomoroContracts.Enums.ErrorCodes.InvalidProperty => ErrorWarningTypes.Authentication,
            KomoroContracts.Enums.ErrorCodes.InvalidRoomType => ErrorWarningTypes.BusinessRule,
            KomoroContracts.Enums.ErrorCodes.InvalidRatePlan => ErrorWarningTypes.BusinessRule,
            _ => throw new NotImplementedException()
        };

        var errorCode = errorDetails.ErrorCode switch
        {
            KomoroContracts.Enums.ErrorCodes.InvalidProperty => ErrorCodes.InvalidHotel,
            KomoroContracts.Enums.ErrorCodes.InvalidRatePlan => ErrorCodes.InvalidRateCode,
            KomoroContracts.Enums.ErrorCodes.InvalidRoomType => ErrorCodes.InvalidRoomType,
            _ => throw new NotImplementedException()
        };

        return ErrorHelper.GetError(errorWarningType, errorCode, errorDetails.ObjectCode);
    }
}
