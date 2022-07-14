using CSharpFunctionalExtensions;
using HappyTravel.EdoContracts.Accommodations;
using HappyTravel.EdoContracts.Accommodations.Internals;
using HappyTravel.Komoro.Api.Services.Converters;
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
        foreach (var propertyCode in request.AccommodationIds)
        {
            List<RoomContract> roomContracts = new(0);
            foreach (var roomOccupationRequest in request.Rooms)
            {
                var rooms = await _komoroContext.Rooms.Include(r => r.Property)
                    .Where(r => r.Property.SupplierCode == supplierCode && r.Property.Code == propertyCode
                        && r.MaximumOccupancy.Any(o => o.Adults >= roomOccupationRequest.AdultsNumber && o.Children >= roomOccupationRequest.ChildrenAges.Count))
                    .ToListAsync(cancellationToken);

                var inventories = await _komoroContext.Inventories.Include(i => i.Property)
                    .Include(i => i.RoomType)
                    .Where(i => i.Property.SupplierCode == supplierCode && i.Property.Code == propertyCode
                        && rooms.Any(r => r.RoomType == i.RoomType)
                        && i.StartDate <= DateOnly.FromDateTime(request.CheckInDate.Date)   // Need to clarify after receiving data from the supplier
                        && i.EndDate >= DateOnly.FromDateTime(request.CheckOutDate.Date)    // Need to clarify after receiving data from the supplier
                        && i.NumberOfAvailableRooms > 0)
                    .ToListAsync(cancellationToken);

                var availabilityRestrictions = await _komoroContext.AvailabilityRestrictions.Include(i => i.Property)
                    .Where(ar => ar.Property.SupplierCode == supplierCode && ar.Property.Code == propertyCode)
                    .ToListAsync(cancellationToken);

                roomContracts = inventories.Select(i => WideAvailabilitySearchConverter.Convert(i, roomOccupationRequest)).ToList();
            }
            var roomContractSet = new RoomContractSet(id: Guid.NewGuid(),
                rate: new EdoContracts.General.Rate(),  // Need clarify
                deadline: new Deadline(),   // Need clarify
                rooms: roomContracts,
                tags: new List<string>(),
                isDirectContract: false,
                isAdvancePurchaseRate: false,
                isPackageRate: false);
        }

        throw new NotImplementedException();
    }


    private readonly KomoroContext _komoroContext;
}
