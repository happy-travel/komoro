using FloxDc.CacheFlow;
using HappyTravel.Komoro.Data;

namespace HappyTravel.Komoro.Api.Services;

public class AccommodationStorage : IAccommodationStorage
{
    public AccommodationStorage(IMemoryFlow flow, KomoroContext komoroContext)
    {
        _flow = flow;
        _komoroContext = komoroContext;
    }


    private static readonly TimeSpan accommodationLifeTime = TimeSpan.FromHours(24);

    private readonly IMemoryFlow _flow;
    private readonly KomoroContext _komoroContext;
}
