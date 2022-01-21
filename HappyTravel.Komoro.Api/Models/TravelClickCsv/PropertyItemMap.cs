using CsvHelper.Configuration;

namespace HappyTravel.Komoro.Api.Models.TravelClickCsv;

public sealed class PropertyItemMap : ClassMap<PropertyItem>
{
    public PropertyItemMap()
    {
        Map(pi => pi.Key).Index(1);
        Map(pi => pi.Value).Index(3);
    }
}
