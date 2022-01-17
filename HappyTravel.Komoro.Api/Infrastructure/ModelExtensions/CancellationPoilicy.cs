using ApiModels = HappyTravel.Komoro.Api.Models;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;

public static class CancellationPolicyExtension
{
    public static ApiModels.CancellationPolicy ToApiCancellationPolicy(this DataModels.CancellationPolicy cancellationPolicy)
    {
        return new ApiModels.CancellationPolicy
        {
            Id = cancellationPolicy.Id,
            PropertyId = cancellationPolicy.PropertyId,
            FromDate = cancellationPolicy.FromDate,
            ToDate = cancellationPolicy.ToDate,
            SeasonalityOrEvent = cancellationPolicy.SeasonalityOrEvent,
            Deadline = cancellationPolicy.Deadline,
            NoShow = cancellationPolicy.NoShow
        };
    }
}
