using CSharpFunctionalExtensions;
using FluentValidation;
using HappyTravel.Komoro.Api.Infrastructure;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;
using HappyTravel.Komoro.Data;
using Microsoft.EntityFrameworkCore;
using ApiModels = HappyTravel.KomoroContracts.Statics;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Services;

public class CountryService : ICountryService
{
    public CountryService(KomoroContext komoroContext)
    {
        _komoroContext = komoroContext;
    }


    public async Task<List<ApiModels.Country>> Get(CancellationToken cancellationToken)
    {
        return await _komoroContext.Countries.Select(c => c.ToApiCountry())
            .ToListAsync(cancellationToken);
    }


    public async Task<Result> Add(ApiModels.Country apiCountry, CancellationToken cancellationToken)
    {
        return await Validate(apiCountry)
            .Ensure(() => CountryHasNoDuplicates(apiCountry), "Adding country has duplicate")
            .Tap(Add);


        async Task<bool> CountryHasNoDuplicates(ApiModels.Country country)
            => !await _komoroContext.Countries.Where(c => c.Alpha2Code == country.Alpha2Code || c.Name == country.Name)
                .AnyAsync(cancellationToken);


        async Task Add()
        {
            var utcNow = DateTimeOffset.UtcNow;
            var country = new DataModels.Country
            {
                Alpha2Code = apiCountry.Alpha2Code,
                Name = apiCountry.Name,
                Created = utcNow,
                Modified = utcNow
            };

            _komoroContext.Countries.Add(country);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Modify(int countryId, ApiModels.Country apiCountry, CancellationToken cancellationToken)
    {
        return await Validate(apiCountry)
            .Ensure(() => CountryHasNoDuplicates(apiCountry), "Modifiable country has duplicate")
            .Bind(() => Get(countryId, cancellationToken))
            .Tap(Update);


        async Task<bool> CountryHasNoDuplicates(ApiModels.Country country)
            => !await _komoroContext.Countries.Where(c => (c.Alpha2Code == country.Alpha2Code || c.Name == country.Name) && c.Id != countryId)
                .AnyAsync(cancellationToken);


        async Task Update(DataModels.Country country)
        {
            country.Alpha2Code = apiCountry.Alpha2Code.ToUpperInvariant();
            country.Name = apiCountry.Name;
            country.Modified = DateTimeOffset.UtcNow;

            _komoroContext.Countries.Update(country);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Remove(int countryId, CancellationToken cancellationToken)
    {
        return await Get(countryId, cancellationToken)
            .Tap(Remove);


        async Task Remove(DataModels.Country country)
        {
            _komoroContext.Countries.Remove(country);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    private static Result Validate(ApiModels.Country country)
        => GenericValidator<ApiModels.Country>.Validate(v =>
        {
            v.RuleFor(c => c.Alpha2Code).NotEmpty().MinimumLength(2).MaximumLength(2);
            v.RuleFor(c => c.Name).NotEmpty();
        },
        country);


    private async Task<Result<DataModels.Country>> Get(int countryId, CancellationToken cancellationToken)
    {
        var country = await _komoroContext.Countries.SingleOrDefaultAsync(c => c.Id == countryId, cancellationToken);
        
        return country is not null
            ? country
            : Result.Failure<DataModels.Country>($"Country with id {countryId} not found");
    }


    private readonly KomoroContext _komoroContext;
}
