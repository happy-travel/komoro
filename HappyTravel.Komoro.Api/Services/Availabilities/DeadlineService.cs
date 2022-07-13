using CSharpFunctionalExtensions;
using HappyTravel.EdoContracts.Accommodations;

namespace HappyTravel.Komoro.Api.Services.Availabilities
{
    public class DeadlineService : IDeadlineService
    {
        public async Task<Result<Deadline>> Get(string supplierCode, string availabilityId, Guid roomContractSetId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
