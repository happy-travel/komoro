using HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Ping;
using System;
using System.IO;
using System.Xml.Serialization;
using Xunit;

namespace HappyTravel.Komoro.UnitTests;

public class TravelClickXmlSerializationTests
{
    [Fact]
    public void OtaPingRQSerializationTest()
    {
        var data = new OtaPingRQ
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoData = "Test only"
        };

        var fileName = $"{typeof(OtaPingRQ)}.xml";
        var xmlSerializer = new XmlSerializer(typeof(OtaPingRQ));
        var streamWriter = new StreamWriter(fileName);
        xmlSerializer.Serialize(streamWriter, data);
        streamWriter.Close();

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaPingRSSerializationTest()
    {
        var data = new OtaPingRS
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            Success = new(),
            EchoData = "Test only"
        };

        var fileName = $"{typeof(OtaPingRS)}.xml";
        var xmlSerializer = new XmlSerializer(typeof(OtaPingRS));
        var streamWriter = new StreamWriter(fileName);
        xmlSerializer.Serialize(streamWriter, data);
        streamWriter.Close();

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaHotelProductRQSerializationTest()
    {
        var data = new OtaHotelProductRQ
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoToken = "001-1466531393",
            Pos = new Pos
            {
                Source = new Source
                {
                    BookingChannel = new BookingChannel
                    {
                        Type = "7",
                        CompanyName = new CompanyName
                        {
                            Name = "Partner Name",
                            Code = "PartnerCode"
                        }
                    }
                }
            },
            HotelProducts = new HotelProduct[1]
            {
                new HotelProduct
                {
                    HotelCode = "HOTEL001"
                }
            }
        };

        var fileName = $"{typeof(OtaHotelProductRQ)}.xml";
        var xmlSerializer = new XmlSerializer(typeof(OtaHotelProductRQ));
        var streamWriter = new StreamWriter(fileName);
        xmlSerializer.Serialize(streamWriter, data);
        streamWriter.Close();

        Assert.True(File.Exists(fileName));
    }
}
