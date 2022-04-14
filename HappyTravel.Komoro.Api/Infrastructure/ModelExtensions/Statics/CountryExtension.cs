using ApiModels = HappyTravel.KomoroContracts.Statics;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Statics;

public static class CountryExtension
{
    public static ApiModels.Country ToApiCountry(this DataModels.Country country)
    {
        return new ApiModels.Country
        {
            Id = country.Id,
            Alpha2Code = country.Alpha2Code,
            Name = country.Name
        };
    }
}
