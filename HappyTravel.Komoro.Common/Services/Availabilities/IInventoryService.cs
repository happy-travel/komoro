using HappyTravel.KomoroContracts;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.Common.Services.Availabilities;

public interface IInventoryService
{
    Task<(Inventory, List<ErrorDetails>)> Get(InventoryRequest request);
    Task<List<ErrorDetails>> Update(Inventory inventory);
}
