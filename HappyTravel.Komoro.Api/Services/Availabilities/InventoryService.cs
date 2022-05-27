using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.Common.Services.Statics;
using HappyTravel.Komoro.Data;
using HappyTravel.KomoroContracts;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public class InventoryService : IInventoryService
{
    public InventoryService(KomoroContext komoroContext, IDateTimeOffsetProvider dateTimeOffsetProvider, IPropertyService propertyService, IRoomTypeService roomTypeService)
    {
        _komoroContext = komoroContext;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _propertyService = propertyService;
        _roomTypeService = roomTypeService;
    }


    public async Task<(Inventory, List<ErrorDetails>)> Get(InventoryRequest request)
    {
        throw new NotImplementedException();
    }


    public async Task<List<ErrorDetails>> Update(Inventory inventory)
    {
        throw new NotImplementedException();
    }


    private readonly KomoroContext _komoroContext;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IPropertyService _propertyService;
    private readonly IRoomTypeService _roomTypeService;
}
