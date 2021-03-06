using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.UnitTests.Infrastructure;
using HappyTravel.Money.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Availability = HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;
using AvailabilityRequests = HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using AvailabilityResponses = HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

namespace HappyTravel.Komoro.UnitTests.TravelClick;

public class AvailabilityXmlSerializationTests
{
    [Fact]
    public void OtaHotelAvailNotifRQSerializationTest()
    {
        var data = new AvailabilityRequests.OtaHotelAvailNotifRQ
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
            AvailStatusMessages = new Availability.AvailStatusMessages
            {
                HotelCode = "HOTEL001",
                AvailStatusMessageList = new List<Availability.AvailStatusMessage>
                {
                    new Availability.AvailStatusMessage
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 15),
                            End = new DateTime(2017, 1, 16),
                            InvTypeCode="DBL",
                            RatePlanCode="AP"
                        },
                        LengthsOfStay = new Availability.LengthsOfStay
                        {
                            ArrivalDateBased = true,
                            LengthOfStayList = new List<Availability.LengthOfStay>
                            {
                                new Availability.LengthOfStay
                                {
                                    MinMaxMessageType = "MinLOS",
                                    TimeUnit = "Day",
                                    Time = 3
                                }
                            }
                        }
                    },
                    new Availability.AvailStatusMessage
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 15),
                            End = new DateTime(2017, 1, 16),
                            InvTypeCode="DBL",
                            RatePlanCode="AP"
                        },
                        RestrictionStatus = new Availability.RestrictionStatus
                        { 
                            Restriction = "Master",
                            Status = "Open"
                        }
                    },
                    new Availability.AvailStatusMessage
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 15),
                            End = new DateTime(2017, 1, 16),
                            InvTypeCode = "DBL",
                            RatePlanCode = "AP"
                        },
                        RestrictionStatus = new Availability.RestrictionStatus
                        {
                            Restriction = "Arrival",
                            Status = "Close"
                        }
                    },
                    new Availability.AvailStatusMessage
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 15),
                            End = new DateTime(2017, 1, 16),
                            InvTypeCode = "DBL",
                            RatePlanCode = "AP"
                        },
                        RestrictionStatus = new Availability.RestrictionStatus
                        {
                            MinAdvancedBookingOffset = "P7D"
                        }
                    }
                }
            }
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaHotelAvailNotifRSSerializationTest()
    {
        var data = new AvailabilityResponses.OtaHotelAvailNotifRS
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoToken = "001-1466531393",
            Success = new()
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaHotelInvCountNotifRQSerializationTest()
    {
        var data = new AvailabilityRequests.OtaHotelInvCountNotifRQ
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
            Inventories = new Availability.Inventories
            {
                HotelCode = "HOTEL001",
                InventoryList = new List<Availability.Inventory>
                {
                    new Availability.Inventory
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 15),
                            End = new DateTime(2017, 1, 15),
                            InvTypeCode="DBL",
                            RatePlanCode="BAR"
                        },
                        InvCounts = new List<Availability.InvCount>
                        {
                            new Availability.InvCount
                            {
                                Count = 25,
                                CountType = "2"
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
    public void OtaHotelInvCountNotifRSSerializationTest()
    {
        var data = new AvailabilityResponses.OtaHotelInvCountNotifRS
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoToken = "001-1466531393",
            Success = new()
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaHotelRatePlanNotifRQSerializationTest()
    {
        var data = new AvailabilityRequests.OtaHotelRatePlanNotifRQ
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
            RatePlans = new Availability.RatePlans
            {
                HotelCode = "HOTEL001",
                PatePlanList = new List<Availability.RatePlan>
                {
                    new Availability.RatePlan
                    {
                        RatePlanCode = "BAR",
                        Start = new DateTime(2017, 1, 1),
                        End = new DateTime(2017, 1, 15),
                        Rates = new List<Availability.Rate>
                        {
                            new Availability.Rate
                            {
                                InvTypeCode = "DBL",
                                CurrencyCode = Currencies.USD,
                                BaseByGuestAmts = new List<Availability.BaseByGuestAmt>
                                {
                                    new Availability.BaseByGuestAmt
                                    {
                                        AmountBeforeTax = 100.00m,
                                        NumberOfGuests = 1,
                                        AgeQualifyingCode = "10"
                                    },
                                    new Availability.BaseByGuestAmt
                                    {
                                        AmountBeforeTax = 100.00m,
                                        NumberOfGuests = 2,
                                        AgeQualifyingCode = "10"
                                    }
                                },
                                AdditionalGuestAmounts = new List<Availability.AdditionalGuestAmount>
                                {
                                    new Availability.AdditionalGuestAmount
                                    {
                                        Amount = 25.00m,
                                        AgeQualifyingCode = "10"
                                    },
                                    new Availability.AdditionalGuestAmount
                                    {
                                        Amount = 0.00m,
                                        AgeQualifyingCode = "8"
                                    }
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
    public void OtaHotelRatePlanNotifRSSerializationTest()
    {
        var data = new AvailabilityResponses.OtaHotelRatePlanNotifRS
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoToken = "001-1466531393",
            Success = new()
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaHotelAvailGetRQSerializationTest()
    {
        var data = new AvailabilityRequests.OtaHotelAvailGetRQ
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
            HotelAvailRequests = new List<AvailabilityRequests.HotelAvailRequest>
            {
                new AvailabilityRequests.HotelAvailRequest
                {
                    DateRange = new AvailabilityRequests.DateRange
                    {
                        Start = new DateTime(2017, 1, 1),
                        End = new DateTime(2017, 1, 3)
                    },
                    RatePlanCandidates = new List<AvailabilityRequests.RatePlanCandidate>
                    {
                        new AvailabilityRequests.RatePlanCandidate
                        {
                            RatePlanCode = "BAR"
                        }
                    },
                    RoomTypeCandidates = new List<AvailabilityRequests.RoomTypeCandidate>
                    {
                        new AvailabilityRequests.RoomTypeCandidate
                        {
                            RoomTypeCode="SGL"
                        },
                        new AvailabilityRequests.RoomTypeCandidate
                        {
                            RoomTypeCode="DBL"
                        }
                    },
                    HotelRef = new AvailabilityRequests.HotelRef
                    {
                        HotelCode = "HOTEL001"
                    }
                }
            }
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaHotelAvailGetRSSerializationTest()
    {
        var data = new AvailabilityResponses.OtaHotelAvailGetRS
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoToken = "001-1466531393",
            Success = new(),
            AvailStatusMessages = new Availability.AvailStatusMessages
            {
                HotelCode = "HOTEL001",
                AvailStatusMessageList = new List<Availability.AvailStatusMessage>
                {
                    new Availability.AvailStatusMessage
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 1),
                            End = new DateTime(2017, 1, 3),
                            InvTypeCode = "SGL",
                            RatePlanCode = "BAR"
                        },
                        LengthsOfStay = new Availability.LengthsOfStay
                        {
                            ArrivalDateBased = false,
                            LengthOfStayList = new List<Availability.LengthOfStay>
                            {
                                new Availability.LengthOfStay
                                {
                                    MinMaxMessageType = "MinLOS",
                                    TimeUnit = "Day",
                                    Time = 1
                                }
                            }
                        }
                    },
                    new Availability.AvailStatusMessage
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 1),
                            End = new DateTime(2017, 1, 3),
                            InvTypeCode = "SGL",
                            RatePlanCode = "BAR"
                        },
                        RestrictionStatus = new Availability.RestrictionStatus
                        {
                            Restriction = "Master",
                            Status = "Open"
                        }
                    },
                    new Availability.AvailStatusMessage
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 1),
                            End = new DateTime(2017, 1, 3),
                            InvTypeCode = "SGL",
                            RatePlanCode = "BAR"

                        },
                        RestrictionStatus = new Availability.RestrictionStatus
                        {
                            Restriction = "Arrival",
                            Status = "Open"
                        }
                    },
                    new Availability.AvailStatusMessage
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 1),
                            End = new DateTime(2017, 1, 3),
                            InvTypeCode = "SGL",
                            RatePlanCode = "BAR"

                        },
                        RestrictionStatus = new Availability.RestrictionStatus
                        {
                            MinAdvancedBookingOffset = "P0D"
                        }
                    }
                }
            }
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaHotelInvCountRQSerializationTest()
    {
        var data = new AvailabilityRequests.OtaHotelInvCountRQ
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
            HotelInvCountRequests = new List<AvailabilityRequests.HotelInvCountRequest>
            {
                new AvailabilityRequests.HotelInvCountRequest
                {
                    DateRange = new AvailabilityRequests.DateRange
                    {
                        Start = new DateTime(2017, 1, 1),
                        End = new DateTime(2017, 1, 3)
                    },
                    RoomTypeCandidates = new List<AvailabilityRequests.RoomTypeCandidate>
                    {
                        new AvailabilityRequests.RoomTypeCandidate
                        {
                            RoomTypeCode="SGL"
                        }
                    },
                    HotelRef = new AvailabilityRequests.HotelRef
                    {
                        HotelCode = "HOTEL001"
                    }
                }
            }
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaHotelInvCountRSSerializationTest()
    {
        var data = new AvailabilityResponses.OtaHotelInvCountRS
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoToken = "001-1466531393",
            Success = new(),
            Inventories = new Availability.Inventories
            {
                HotelCode = "HOTEL001",
                InventoryList = new List<Availability.Inventory>
                {
                    new Availability.Inventory
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 1),
                            End = new DateTime(2017, 1, 1),
                            InvTypeCode = "SGL",
                            RatePlanCode = "BAR"
                        },
                        InvCounts = new List<Availability.InvCount>
                        {
                            new Availability.InvCount
                            {
                                Count = 18,
                                CountType = "2"
                            },
                            new Availability.InvCount
                            {
                                Count = 2,
                                CountType = "4"
                            }
                        }
                    },
                    new Availability.Inventory
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 1),
                            End = new DateTime(2017, 1, 3),
                            InvTypeCode = "SGL",
                            RatePlanCode = "BAR"
                        },
                        InvCounts = new List<Availability.InvCount>
                        {
                            new Availability.InvCount
                            {
                                Count = 20,
                                CountType = "2"
                            },
                            new Availability.InvCount
                            {
                                Count = 0,
                                CountType = "4"
                            }
                        }
                    },
                    new Availability.Inventory
                    {
                        StatusApplicationControl = new Availability.StatusApplicationControl
                        {
                            Start = new DateTime(2017, 1, 1),
                            End = new DateTime(2017, 1, 1),
                            InvTypeCode = "SGL",
                            RatePlanCode = "ADVPURCHASE"
                        },
                        InvCounts = new List<Availability.InvCount>
                        {
                            new Availability.InvCount
                            {
                                Count = 20,
                                CountType = "2"
                            },
                            new Availability.InvCount
                            {
                                Count = 0,
                                CountType = "4"
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
    public void OtaHotelRatePlanRQSerializationTest()
    {
        var data = new AvailabilityRequests.OtaHotelRatePlanRQ
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
            RatePlans = new List<AvailabilityRequests.RatePlanWithCandidates>
            {
                new AvailabilityRequests.RatePlanWithCandidates
                {
                    DateRange = new AvailabilityRequests.DateRange
                    {
                        Start = new DateTime(2017, 1, 1),
                        End = new DateTime(2017, 1, 3)
                    },
                    RatePlanCandidates = new List<AvailabilityRequests.RatePlanCandidate>
                    {
                        new AvailabilityRequests.RatePlanCandidate
                        {
                            RatePlanCode="BAR"
                        }
                    },
                    HotelRef = new AvailabilityRequests.HotelRef
                    {
                        HotelCode="HOTEL001"
                    }
                }
            }
        };

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }


    [Fact]
    public void OtaHotelRatePlanRSSerializationTest()
    {
        var data = new AvailabilityResponses.OtaHotelRatePlanRS
        {
            Version = "1.0",
            TimeStamp = DateTime.Now,
            EchoToken = "001-1466531393",
            Success = new(),
            RatePlans = new Availability.RatePlans
            {
                HotelCode = "HOTEL001",
                PatePlanList = new List<Availability.RatePlan>
                {
                    new Availability.RatePlan
                    {
                        RatePlanCode = "BAR",
                        Start = new DateTime(2017, 1, 1),
                        End = new DateTime(2017, 1, 3),
                        Rates = new List<Availability.Rate>
                        {
                            new Availability.Rate
                            {
                                InvTypeCode = "SGL",
                                CurrencyCode = Currencies.USD,
                                BaseByGuestAmts = new List<Availability.BaseByGuestAmt>
                                {
                                    new Availability.BaseByGuestAmt
                                    {
                                        AmountBeforeTax = 100.00m,
                                        NumberOfGuests = 1
                                    },
                                    new Availability.BaseByGuestAmt
                                    {
                                        AmountBeforeTax = 100.00m,
                                        NumberOfGuests = 2
                                    }
                                },
                                AdditionalGuestAmounts = new List<Availability.AdditionalGuestAmount>
                                {
                                    new Availability.AdditionalGuestAmount
                                    {
                                        Amount = 25.00m,
                                        AgeQualifyingCode = "10"
                                    },
                                    new Availability.AdditionalGuestAmount
                                    {
                                        Amount = 0m,
                                        AgeQualifyingCode = "8"
                                    }
                                }
                            },
                            new Availability.Rate
                            {
                                InvTypeCode = "DBL",
                                CurrencyCode = Currencies.USD,
                                BaseByGuestAmts = new List<Availability.BaseByGuestAmt>
                                {
                                    new Availability.BaseByGuestAmt
                                    {
                                        AmountBeforeTax = 150.00m,
                                        NumberOfGuests = 1
                                    },
                                    new Availability.BaseByGuestAmt
                                    {
                                        AmountBeforeTax = 150.00m,
                                        NumberOfGuests = 2
                                    }
                                },
                                AdditionalGuestAmounts = new List<Availability.AdditionalGuestAmount>
                                {
                                    new Availability.AdditionalGuestAmount
                                    {
                                        Amount = 35.00m,
                                        AgeQualifyingCode = "10"
                                    },
                                    new Availability.AdditionalGuestAmount
                                    {
                                        Amount = 0m,
                                        AgeQualifyingCode = "8"
                                    }
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
}
