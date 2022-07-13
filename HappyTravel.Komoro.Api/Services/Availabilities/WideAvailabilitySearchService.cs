using CSharpFunctionalExtensions;
using HappyTravel.EdoContracts.Accommodations;
using HappyTravel.Komoro.Data;
using Microsoft.EntityFrameworkCore;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public class WideAvailabilitySearchService : IWideAvailabilitySearchService
{
    public WideAvailabilitySearchService(KomoroContext komoroContext)
    {
        _komoroContext = komoroContext;
    }


    public async Task<Result<Availability>> Get(string supplierCode, AvailabilityRequest request, CancellationToken cancellationToken)
    {
        foreach (var roomOccupationRequest in request.Rooms)
        {
            foreach (var propertyCode in request.AccommodationIds)
            {
                var rooms = await _komoroContext.Rooms.Include(r => r.Property)
                    .Where(r => r.Property.SupplierCode == supplierCode && r.Property.Code == propertyCode)
                    .ToListAsync(cancellationToken);

                var inventories = await _komoroContext.Inventories.Include(i => i.Property)
                    .Include(i => i.RoomType)
                    .Where(i => i.Property.SupplierCode == supplierCode && i.Property.Code == propertyCode
                        && i.RoomType.
                        && i.StartDate <= DateOnly.FromDateTime(request.CheckInDate.Date)   // Need to clarify
                        && i.EndDate >= DateOnly.FromDateTime(request.CheckOutDate.Date)    // Need to clarify
                        && i.NumberOfAvailableRooms > 0)
                    .ToListAsync(cancellationToken);
            }

        }




        throw new NotImplementedException();
    }


    private readonly KomoroContext _komoroContext;
}
