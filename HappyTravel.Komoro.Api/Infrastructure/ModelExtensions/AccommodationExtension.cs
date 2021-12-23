using HappyTravel.Komoro.Api.Models;
using HappyTravel.Komoro.Data.Models;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;

public static class AccommodationExtension
{
    public static SlimAccommodation ToSlimAccommodation(this Accommodation supplier)
    {
        return new SlimAccommodation
        {
            Id = supplier.Id,
            Name = supplier.Name
        };
    }


    public static RichAccommodation ToRichAccommodation(this Accommodation supplier)
    {
        return new RichAccommodation
        {
            Id = supplier.Id,
            Name = supplier.Name
        };
    }
}
