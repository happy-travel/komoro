using CSharpFunctionalExtensions;
using HappyTravel.Komoro.Api.Models;
using HappyTravel.Komoro.Data;

namespace HappyTravel.Komoro.Api.Services;

public class AccommodationService : IAccommodationService
{
    public AccommodationService(KomoroContext komoroContext, IAccommodationStorage accommodationStorage)
    {
        _komoroContext = komoroContext;
        _accommodationStorage = accommodationStorage;
    }


    public async Task<List<SlimAccommodation>> Get(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public async Task<Result<RichAccommodation>> Get(int accommodationId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<Result> Add(RichAccommodation richAccommodation, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<Result> Modify(int supplierId, RichAccommodation richAccommodation, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<Result> Delete(int accommodationId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    private readonly KomoroContext _komoroContext;
    private readonly IAccommodationStorage _accommodationStorage;
}
