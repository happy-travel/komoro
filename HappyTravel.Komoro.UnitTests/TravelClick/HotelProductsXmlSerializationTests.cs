using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;
using HappyTravel.Komoro.UnitTests.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using HotelProductRequests = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;
using HotelProductResponses = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

namespace HappyTravel.Komoro.UnitTests.TravelClick;

public class HotelProductsXmlSerializationTests
{
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

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }

    [Fact]
    public void OtaHotelProductRSSerializationTest()
    {
        var hotelProducts = new HotelProducts
        {
            HotelCode = "HOTEL001",
            HotelProductList = new List<HotelProductResponses.HotelProduct>
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
        var data = new OtaHotelProductRS
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoToken = "001-1466531393",
            Success = new(),
            HotelProducts = hotelProducts 
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }
}
