using CSharpFunctionalExtensions;
using HappyTravel.EdoContracts.Accommodations;
using HappyTravel.EdoContracts.Accommodations.Internals;
using HappyTravel.EdoContracts.General.Enums;
using HappyTravel.Komoro.Api.Services.Converters;
using HappyTravel.Komoro.Data;
using HappyTravel.Komoro.Data.Models.Availabilities;
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
        var accommodationAvailabilities = new List<SlimAccommodationAvailability>();
        var checkInDate = DateOnly.FromDateTime(request.CheckInDate.Date);
        var checkOutDate = DateOnly.FromDateTime(request.CheckOutDate.Date);

        foreach (var propertyCode in request.AccommodationIds)
        {
            var cancellationPolicies = await _komoroContext.CancellationPolicies.Include(cp => cp.Property)
                .Where(cp => cp.Property.SupplierCode == supplierCode && cp.Property.Code == propertyCode
                    && (cp.FromDate <= checkInDate && cp.ToDate >= checkOutDate)
                    || (cp.FromDate <= checkInDate && cp.ToDate < checkOutDate)
                    || (cp.FromDate > checkInDate && cp.ToDate >= checkOutDate))
                .ToListAsync(cancellationToken);
            var deadline = GetDeadline(cancellationPolicies);

            var roomContractsOnRequest = new List<List<RoomContract>>(request.Rooms.Count);
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
                        && i.StartDate <= checkInDate   // TODO: Need to clarify after receiving data from the supplier
                        && i.EndDate >= checkOutDate    // TODO: Need to clarify after receiving data from the supplier
                        && i.NumberOfAvailableRooms > 0)
                    .ToListAsync(cancellationToken);

                var rates = await _komoroContext.Rates.Include(r => r.Property)
                    .Include(r => r.RoomType)
                    .Where(r => r.Property.SupplierCode == supplierCode && r.Property.Code == propertyCode
                        && rooms.Any(room => room.RoomType == r.RoomType)
                        && r.StartDate <= checkInDate   // TODO: Need to clarify after receiving data from the supplier
                        && r.EndDate >= checkOutDate)   // TODO: Need to clarify after receiving data from the supplier
                    .ToListAsync(cancellationToken);

                var availabilityRestrictions = await _komoroContext.AvailabilityRestrictions.Include(i => i.Property)   // TODO: Need clarify
                    .Where(ar => ar.Property.SupplierCode == supplierCode && ar.Property.Code == propertyCode
                        && (ar.StartDate <= checkInDate && ar.EndDate >= checkOutDate)
                        || (ar.StartDate <= checkInDate && ar.EndDate < checkOutDate)
                        || (ar.StartDate > checkInDate && ar.EndDate >= checkOutDate))
                    .ToListAsync(cancellationToken);

                var roomContracts = inventories.Select(i 
                    => WideAvailabilitySearchConverter.Convert(i, GetRoom(i), GetRates(rates, i), deadline, roomOccupationRequest, request))
                    .ToList();
                roomContractsOnRequest.Add(roomContracts);
            }

            var roomContractCombinations = GetAllCombinations(roomContractsOnRequest);
            var roomContractSets = new List<RoomContractSet>();
            foreach (var roomContractCombination in roomContractCombinations)
            {
                var roomContractSet = new RoomContractSet(id: Guid.NewGuid(),
                    rate: GetRate(roomContractCombination),
                    deadline: deadline,
                    rooms: roomContractCombination,
                    tags: new List<string>(),
                    isDirectContract: false,
                    isAdvancePurchaseRate: false,
                    isPackageRate: false);
                roomContractSets.Add(roomContractSet);
            }

            var accommodationAvailability = new SlimAccommodationAvailability(accommodationId: propertyCode,
                roomContractSets : roomContractSets,
                availabilityId: GenerateAvailabilityId());
            accommodationAvailabilities.Add(accommodationAvailability);


            List<Rate> GetRates(List<Rate> rates, Inventory inventory)
            {
                return rates.Where(r => r.RatePlanCode == inventory.RatePlanCode && r.RoomTypeId == inventory.RoomTypeId)
                    .ToList();
            }
        }

        var availability = new Availability(availabilityId: GenerateAvailabilityId(),
            numberOfNights: (request.CheckOutDate - request.CheckInDate).Days, 
            checkInDate: request.CheckInDate, 
            checkOutDate: request.CheckOutDate, 
            expiredAfter: DateTimeOffset.UtcNow.Add(availabilityLifetime), 
            results: accommodationAvailabilities, 
            numberOfProcessedAccommodations: accommodationAvailabilities.Count);

        return availability;


        Deadline GetDeadline(List<Data.Models.Statics.CancellationPolicy> cancellationPolicies)
        {
            var firstCancellationPolicy = cancellationPolicies.OrderByDescending(cp => cp.Deadline)
                .FirstOrDefault();
            DateTimeOffset? date = firstCancellationPolicy is not null 
                ? request.CheckInDate.AddDays(-firstCancellationPolicy.Deadline)
                : null;
            var policies = cancellationPolicies
                .Select(cp => new CancellationPolicy(fromDate: request.CheckInDate.AddDays(-cp.Deadline), 
                    percentage: cp.Percentage, 
                    remark: null))
                .ToList();

            return new Deadline(date: date, 
                policies: policies, 
                remarks: null, 
                isFinal: true);
        }
    }


    private static List<List<RoomContract>> GetAllCombinations(List<List<RoomContract>> allRoomContracts)
    {
        var roomContractCombinations = new List<List<RoomContract>>();
        var numberOfRooms = allRoomContracts.Count;
        var numberOfOffers = new int[numberOfRooms];
        var totalCombinations = 1;
        for (int i = 0; i < numberOfRooms; i++)
        {
            numberOfOffers[i] = allRoomContracts[i].Count;
            totalCombinations *= numberOfOffers[i];
        }

        for (int i = 0; i < totalCombinations; i++)
        {
            var roomContractCombination = new List<RoomContract>(numberOfRooms);
            var divider = 1;
            for (int j = 0; j < numberOfRooms; j++)
            {
                var numberOfOptions = totalCombinations / numberOfOffers[j];
                roomContractCombination.Add(allRoomContracts[j][i / divider % numberOfOptions]);
                divider *= numberOfOffers[j];
            }
            roomContractCombinations.Add(roomContractCombination);
        }

        return roomContractCombinations;
    }


    private Data.Models.Statics.Room GetRoom(Inventory inventory)
    {
        return _komoroContext.Rooms.Include(r => r.StandardMealPlanId)
            .SingleAsync(r => r.PropertyId == inventory.PropertyId && r.RoomType == inventory.RoomType)
            .Result;
    }


    private static EdoContracts.General.Rate GetRate(List<RoomContract> roomContracts)
    {
        var finalPriceAmount = roomContracts.Sum(rc => rc.Rate.FinalPrice.Amount);
        var currency = roomContracts.First().Rate.Currency;

        return new EdoContracts.General.Rate(finalPrice: new Money.Models.MoneyAmount(finalPriceAmount, currency), 
            gross: new Money.Models.MoneyAmount(), 
            discounts: null, 
            type: PriceTypes.RoomContractSet, 
            description: null);
    }


    private static string GenerateAvailabilityId() => Guid.NewGuid().ToString("N");


    private readonly TimeSpan availabilityLifetime = TimeSpan.FromMinutes(30);

    private readonly KomoroContext _komoroContext;
}
