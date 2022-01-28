using CsvHelper.Configuration;

namespace HappyTravel.Komoro.Api.Models.TravelClickCsv;

public sealed class PropertyItemMap : ClassMap<PropertyItem>
{
    public PropertyItemMap()
    {
        Map(pi => pi.Key).Index(KeyColumn);
        Map(pi => pi.Value).Index(ValueColumn);
    }


    private const int KeyColumn = 1;
    private const int ValueColumn = 3;
}
