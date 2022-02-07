using ApiModels = HappyTravel.KomoroContracts.Statics;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;

public static class AddressExtension
{
    public static ApiModels.Address ToApiAddress(this DataModels.Address address, DataModels.Country country)
    {
        return new ApiModels.Address
        {
            Street = address.Street,
            City = address.City,
            PostalCode = address.PostalCode,
            Country = country.ToApiCountry()
        };
    }
}
