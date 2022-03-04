using HappyTravel.Komoro.TravelClickChannelManager.Models;
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
            HotelReservations = new List<Requests.HotelReservation>
            {
                new Requests.HotelReservation
                {
                    ResStatus = "Commit",
                    CreateDateTime = new DateTime(2016, 5, 26, 11, 11, 50),
                    ResGlobalInfo = new Requests.ResGlobalInfo
                    {
                        HotelReservationIDs = new List<Requests.HotelReservationID>
                        {
                            new Requests.HotelReservationID
                            {
                                ResID_Type = "13",
                                ResID_Value = "Max12345"
                            }
                        }
                    },
                    ResGuests = new List<Requests.ResGuest>
                    {
                        new Requests.ResGuest
                        {
                            ResGuestRPH="0",
                            Profiles = new Requests.Profiles
                            {
                                ProfileInfo = new Requests.ProfileInfo
                                {
                                    Profile = new Requests.Profile
                                    {
                                        Customer = new Requests.Customer
                                        {
                                            PersonName = new Requests.PersonName
                                            {
                                                GivenName = "Herbert",
                                                Surname = "Guest"
                                            },
                                            Telephone = "15555555555",
                                            Email = "hguest@company.com",
                                            Address = new Requests.Address
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
                            SpecialRequests = new List<Requests.SpecialRequest>
                            {
                                new Requests.SpecialRequest
                                {
                                    Text = "Two extra towels"
                                }
                            },
                            Comments = new List<Requests.Comment>
                            {
                                new Requests.Comment
                                {
                                    Text = "No comment"
                                }
                            }
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
            Success = new()
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }
}
