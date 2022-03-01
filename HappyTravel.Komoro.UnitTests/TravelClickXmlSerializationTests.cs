using HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Ping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Xunit;
using HotelProductRequests = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;
using HotelProductResponses = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

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

        var fileName = SerializeAndSave(data);

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

        var fileName = SerializeAndSave(data);

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
            HotelProducts = new List<HotelProductRequests.HotelProduct>
            {
                new HotelProductRequests.HotelProduct
                {
                    HotelCode = "HOTEL001"
                }
            }
        };

        var fileName = SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }

    [Fact]
    public void OtaHotelProductRSSerializationTest()
    {
        var data = new OtaHotelProductRS
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoToken = "001-1466531393",
            Success = new(),
                //HotelCode = "HOTEL001",
                HotelProducts = new List<HotelProductResponses.HotelProduct>
                {
                    new HotelProductResponses.HotelProduct
                    {
                        RatePlans = new List<RatePlan>
                        {
                            new RatePlan
                            {
                                RatePlanCode = "BAR",
                                RatePlanName = "Best Available Rate",
                                BaseOccupancy = 2,
                                CurrencyCode = "USD"

                            },
                            new RatePlan
                            {
                                RatePlanCode = "LM",
                                RatePlanName = "Last Minute Rate",
                                BaseOccupancy = 2,
                                CurrencyCode = "USD"
                            }
                        },
                        RoomTypes = new List<RoomType>
                        {
                            new RoomType
                            {
                                RoomTypeCode = "STANDARD",
                                RoomTypeName = "Standard Room",
                                MaxAdultOccupancy = 4
                            },
                            new RoomType
                            {
                                RoomTypeCode = "DBL",
                                RoomTypeName = "Double Room",
                                MaxAdultOccupancy = 4
                            }
                        }
                    },
                    new HotelProductResponses.HotelProduct
                    {
                        RatePlans = new List<RatePlan>
                        {
                            new RatePlan
                            {
                                RatePlanCode = "ADV",
                                RatePlanName = "Advanced Purchase",
                                BaseOccupancy = 2,
                                CurrencyCode = "USD"
                            }
                        },
                        RoomTypes = new List<RoomType>
                        {
                            new RoomType
                            {
                                RoomTypeCode = "DLX",
                                RoomTypeName = "Deluxe Room",
                                MaxAdultOccupancy = 4,
                                MaxChildOccupancy = 2,
                                MaxInfantOccupancy = 2
                            }
                        }
                    }
                }
        };

        var fileName = SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }


    private static string SerializeAndSave<T>(T data)
    {
        var fileName = $"{typeof(T)}.xml";
        var xmlSerializer = new XmlSerializer(typeof(T));
        var streamWriter = new StreamWriter(fileName);
        xmlSerializer.Serialize(streamWriter, data);
        streamWriter.Close();

        return fileName;
    }
}
