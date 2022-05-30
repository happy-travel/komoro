using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;
using HappyTravel.Komoro.TravelClickChannelManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.TravelClickChannelManager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/travel-click/inventory")]
[Produces("application/xml")]
public class InventoryController : BaseController
{
    public InventoryController(ITravelClickInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }


    /// <summary>
    /// Gets Inventory
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(OtaHotelInvCountRS), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromBody] OtaHotelInvCountRQ otaHotelInvCountRQ, CancellationToken cancellationToken)
        => Ok(await _inventoryService.Get(otaHotelInvCountRQ, cancellationToken));


    /// <summary>
    /// Updates Inventory
    /// </summary>
    [HttpPost("update")]
    [ProducesResponseType(typeof(OtaHotelInvCountNotifRS), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] OtaHotelInvCountNotifRQ otaHotelInvCountNotifRQ, CancellationToken cancellationToken)
        => Ok(await _inventoryService.Update(otaHotelInvCountNotifRQ, cancellationToken));


    private readonly ITravelClickInventoryService _inventoryService;
}
