using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.Komoro.TravelClickChannelManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.TravelClickChannelManager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/travel-click/availability-restrictions")]
[Produces("application/xml")]
public class AvailabilityRestrictionController : BaseController
{
    public AvailabilityRestrictionController(IAvailabilityRestrictionService availabilityRestrictionService)
    {
        _availabilityRestrictionService = availabilityRestrictionService;
    }


    private readonly IAvailabilityRestrictionService _availabilityRestrictionService;
}
