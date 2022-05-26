using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.KomoroContracts;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public class InventoryService : IInventoryService
{
    public async Task<(Inventory, List<ErrorDetails>)> Get(InventoryRequest request)
    {
        throw new NotImplementedException();
    }


    public async Task<List<ErrorDetails>> Update(string supplierCode, Inventory inventory)
    {
        throw new NotImplementedException();
    }
}
