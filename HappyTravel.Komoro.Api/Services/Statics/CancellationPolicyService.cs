using CSharpFunctionalExtensions;
using FluentValidation;
using HappyTravel.Komoro.Api.Infrastructure;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Statics;
using HappyTravel.Komoro.Data;
using Microsoft.EntityFrameworkCore;
using ApiModels = HappyTravel.KomoroContracts.Statics;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Services.Statics;

public class CancellationPolicyService : ICancellationPolicyService
{
    public CancellationPolicyService(KomoroContext komoroContext)
    {
        _komoroContext = komoroContext;
    }


    public async Task<List<ApiModels.CancellationPolicy>> Get(int propertyId, CancellationToken cancellationToken)
    {
        return await _komoroContext.CancellationPolicies.Where(cp => cp.PropertyId == propertyId)
            .Select(cp => cp.ToApiCancellationPolicy())
            .ToListAsync(cancellationToken);
    }


    public async Task<Result> Add(int propertyId, ApiModels.CancellationPolicy apiCancellationPolicy, CancellationToken cancellationToken)
    {
        return await Validate(apiCancellationPolicy)
            .Ensure(() => CancellationPolicyHasNoDuplicates(apiCancellationPolicy), "Adding cancellation policy has duplicate")
            .Tap(Add);


        async Task<bool> CancellationPolicyHasNoDuplicates(ApiModels.CancellationPolicy cancellationPolicy)
            => !await _komoroContext.CancellationPolicies.Where(cp => cp.PropertyId == propertyId && cp.FromDate == apiCancellationPolicy.FromDate 
                && cp.ToDate == apiCancellationPolicy.ToDate && cp.Deadline == apiCancellationPolicy.Deadline 
                && cp.Percentage == apiCancellationPolicy.Percentage)
                .AnyAsync(cancellationToken);


        async Task Add()
        {
            var utcNow = DateTimeOffset.UtcNow;
            var cancellationPolicy = new DataModels.CancellationPolicy
            {
                PropertyId = propertyId,
                FromDate = apiCancellationPolicy.FromDate,
                ToDate = apiCancellationPolicy.ToDate,
                SeasonalityOrEvent = apiCancellationPolicy.SeasonalityOrEvent,
                Deadline = apiCancellationPolicy.Deadline,
                Percentage = apiCancellationPolicy.Percentage,
                NoShow = apiCancellationPolicy.NoShow,
                Created = utcNow,
                Modified = utcNow
            };

            _komoroContext.CancellationPolicies.Add(cancellationPolicy);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Modify(int propertyId, int cancellationPolicyId, ApiModels.CancellationPolicy apiCancellationPolicy, 
        CancellationToken cancellationToken)
    {
        return await Validate(apiCancellationPolicy)
            .Ensure(() => CancellationPolicyHasNoDuplicates(apiCancellationPolicy), "Modifiable cancellation policy has duplicate")
            .Bind(() => Get(propertyId, cancellationPolicyId, cancellationToken))
            .Tap(Update);


        async Task<bool> CancellationPolicyHasNoDuplicates(ApiModels.CancellationPolicy cancellationPolicy)
            => !await _komoroContext.CancellationPolicies.Where(cp => cp.PropertyId == propertyId && cp.FromDate == apiCancellationPolicy.FromDate
                && cp.ToDate == apiCancellationPolicy.ToDate && cp.Deadline == apiCancellationPolicy.Deadline
                && cp.Percentage == apiCancellationPolicy.Percentage && cp.Id != cancellationPolicyId)
                .AnyAsync(cancellationToken);


        async Task Update(DataModels.CancellationPolicy cancellationPolicy)
        {
            cancellationPolicy.FromDate = apiCancellationPolicy.FromDate;
            cancellationPolicy.ToDate = apiCancellationPolicy.ToDate;
            cancellationPolicy.SeasonalityOrEvent = apiCancellationPolicy.SeasonalityOrEvent;
            cancellationPolicy.Deadline = apiCancellationPolicy.Deadline;
            cancellationPolicy.Percentage = apiCancellationPolicy.Percentage;
            cancellationPolicy.NoShow = apiCancellationPolicy.NoShow;
            cancellationPolicy.Modified = DateTimeOffset.UtcNow;

            _komoroContext.CancellationPolicies.Update(cancellationPolicy);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Remove(int propertyId, int cancellationPolicyId, CancellationToken cancellationToken)
    {
        return await Get(propertyId, cancellationPolicyId, cancellationToken)
            .Tap(Remove);


        async Task Remove(DataModels.CancellationPolicy cancellationPolicy)
        {
            _komoroContext.CancellationPolicies.Remove(cancellationPolicy);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    private static Result Validate(ApiModels.CancellationPolicy cancellationPolicy)
        => GenericValidator<ApiModels.CancellationPolicy>.Validate(v =>
        {
            v.RuleFor(cp => cp.PropertyId).NotEmpty();
            v.RuleFor(cp => cp.FromDate).NotEmpty();
            v.RuleFor(cp => cp.ToDate).NotEmpty();
            v.RuleFor(cp => cp.Deadline).NotEmpty();
            v.RuleFor(cp => cp.Percentage).NotEmpty();
            v.RuleFor(cp => cp.NoShow).NotEmpty();
        },
        cancellationPolicy);


    private async Task<Result<DataModels.CancellationPolicy>> Get(int propertyId, int cancellationPolicyId, CancellationToken cancellationToken)
    {
        var cancellationPolicy 
            = await _komoroContext.CancellationPolicies.SingleOrDefaultAsync(cp => cp.Id == cancellationPolicyId && cp.PropertyId == propertyId, cancellationToken);
        
        return cancellationPolicy is not null
            ? cancellationPolicy
            : Result.Failure<DataModels.CancellationPolicy>($"Cancellation policy with id {cancellationPolicyId} not found");
    }


    private readonly KomoroContext _komoroContext;
}
