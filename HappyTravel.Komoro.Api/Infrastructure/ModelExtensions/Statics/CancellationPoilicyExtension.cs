using ApiModels = HappyTravel.KomoroContracts.Statics;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Statics;

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
            Percentage = cancellationPolicy.Percentage,
            NoShow = cancellationPolicy.NoShow
        };
    }
}
