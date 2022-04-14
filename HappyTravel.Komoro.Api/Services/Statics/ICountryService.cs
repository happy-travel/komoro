using CSharpFunctionalExtensions;
using HappyTravel.KomoroContracts.Statics;

namespace HappyTravel.Komoro.Api.Services.Statics;

public interface ICountryService
{
    Task<List<Country>> Get(CancellationToken cancellationToken);
    Task<Result> Add(Country country, CancellationToken cancellationToken);
    Task<Result> Modify(int countryId, Country country, CancellationToken cancellationToken);
    Task<Result> Remove(int countryId, CancellationToken cancellationToken);
}
