using CSharpFunctionalExtensions;
using HappyTravel.KomoroContracts.Statics;

namespace HappyTravel.Komoro.Api.Services;

public interface ICancellationPolicyService
{
    Task<List<CancellationPolicy>> Get(int propertyId, CancellationToken cancellationToken);
    Task<Result> Add(int propertyId, CancellationPolicy cancellationPolicy, CancellationToken cancellationToken);
    Task<Result> Modify(int propertyId, int cancellationPolicyId, CancellationPolicy cancellationPolicy, CancellationToken cancellationToken);
    Task<Result> Remove(int propertyId, int cancellationPolicyId, CancellationToken cancellationToken);
}
