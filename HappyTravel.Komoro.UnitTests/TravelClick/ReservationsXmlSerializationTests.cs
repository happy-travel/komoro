using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;
using HappyTravel.Komoro.UnitTests.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Requests = HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Requests;
using Responses = HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Responses;

namespace HappyTravel.Komoro.UnitTests.TravelClick;

/// <summary>
/// 
/// </summary>
public record ReservationsXmlSerializationTests
{
    [Fact]
    public void OtaHotelResNotifRQSerializationTest()
    {
        var data = new Requests.OtaHotelResNotifRQ
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
            HotelReservations = new List<HotelReservation>
            {
                new HotelReservation
                {
                    ResStatus = "Commit",
                    CreateDateTime = new DateTime(2016, 5, 26, 11, 11, 50),
                    ResGlobalInfo = new ResGlobalInfo
                    {
                        HotelReservationIDs = new List<HotelReservationID>
                        {
                            new HotelReservationID
                            {
                                ResID_Type = "13",
                                ResID_Value = "Max12345"
                            }
                        }
                    },
                    ResGuests = new List<ResGuest>
                    {
                        new ResGuest
                        {
                            ResGuestRPH="0",
                            Profiles = new Profiles
                            {
                                ProfileInfo = new ProfileInfo
                                {
                                    Profile = new Profile
                                    {
                                        Customer = new Customer
                                        {
                                            PersonName = new PersonName
                                            {
                                                GivenName = "Herbert",
                                                Surname = "Guest"
                                            },
                                            Telephone = "15555555555",
                                            Email = "hguest@company.com",
                                            Address = new Address
                                            {
                                                AddressLine = "1 Deep Ln",
                                                CityName = "Innsmouth",
                                                StateProv = "MA",
                                                CountryName = "US",
                                                PostalCode = "01966"
                                            }
                                        }
                                    }
                                }
                            },
                            SpecialRequests = new List<SpecialRequest>
                            {
                                new SpecialRequest
                                {
                                    Text = "Two extra towels"
                                }
                            },
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    Text = "No comment"
                                }
                            }
                        }
                    },
                    RoomStays = new List<RoomStay>
                    {
                        new RoomStay
                        {
                            IndexNumber = 1,
                            PromotionCode = "AAA",
                            BasicPropertyInfo = new BasicPropertyInfo
                            {
                                HotelCode = "HOTEL001"
                            },
                            TimeSpan = new TimeSpanRange
                            { 
                                Start = new DateTime(2016, 12, 1),
                                End = new DateTime(2016, 12, 3)
                            },
                            Guarantee = new Guarantee
                            {
                                GuaranteesAccepted = new GuaranteesAccepted
                                {
                                    PaymentCard = new PaymentCard
                                    {
                                        ExpireDate = "0418",
                                        CardType = new CardType
                                        {
                                            Code = "VI"
                                        },
                                        CardNumber = new CardNumber
                                        {
                                            PlainText = "1234123412341234"
                                        },
                                        CardHolderName = "Herbert Guest",
                                        Address = new Address
                                        {
                                            AddressLine = "1 Deep Ln",
                                            CityName = "Innsmouth",
                                            StateProv = "MA",
                                            CountryName = "US",
                                            PostalCode = "01966"
                                        }
                                    }
                                }
                            },
                            GuestCounts = new List<GuestCount>
                            {
                                new GuestCount
                                {
                                    Count = 2,
                                    AgeQualifyingCode = 10
                                }
                            },
                            Total = new Total
                            {
                                CurrencyCode = "USD",
                                AmountBeforeTax = 600.00m,
                                AmountAfterTax = 642.00m
                            },
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    Text = "No comment"
                                }
                            },
                            RoomRates = new List<RoomRate>
                            {
                                new RoomRate
                                {
                                    NumberOfUnits = 1,
                                    RoomTypeCode = "DLX",
                                    RatePlanCode = "BAR",
                                    Rates = new List<Rate>
                                    {
                                        new Rate
                                        {
                                            RoomPricingType = "Per night",
                                            EffectiveDate = new DateTime(2016, 12, 1),
                                            ExpireDate = new DateTime(2016, 12, 3),
                                            Base = new Base
                                            {
                                                AmountBeforeTax = 300.00m
                                            }
                                        }
                                    }

                                }
                            },
                            ResGuestRPHs = 0
                        }
                    }
                }
            }
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaHotelResNotifRSSerializationTest()
    {
        var data = new Responses.OtaHotelResNotifRS
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoToken = "001-1466531393",
            Success = new(),
            HotelReservations = new List<HotelReservation>
            {
                new HotelReservation
                {
                    ResStatus = "Committed",
                    ResGlobalInfo = new ResGlobalInfo
                    {
                        HotelReservationIDs = new List<HotelReservationID>
                        {
                            new HotelReservationID
                            {
                                ResID_Type = "13",
                                ResID_Value = "Max12345"
                            }
                        }
                    }
                }
            }
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }
}
