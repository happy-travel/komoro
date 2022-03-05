﻿using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.Komoro.TravelClickChannelManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.TravelClickChannelManager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/travel-click/inventory")]
[Produces("application/xml")]
public class InventoryController : BaseController
{
    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }


    private readonly IInventoryService _inventoryService;
}
