using HappyTravel.Komoro.Api.Models;
using HappyTravel.Komoro.Data.Models;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;

public static class AccommodationExtension
{
    public static SlimAccommodation ToSlimAccommodation(this Accommodation accommodation)
    {
        return new SlimAccommodation
        {
            Id = accommodation.Id,
            Name = accommodation.Name
        };
    }


    public static RichAccommodation ToRichAccommodation(this Accommodation accommodation)
    {
        return new RichAccommodation
        {
            Id = accommodation.Id,
            Name = accommodation.Name
        };
    }
}
