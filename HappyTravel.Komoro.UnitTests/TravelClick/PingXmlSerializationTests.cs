using HappyTravel.Komoro.TravelClickChannelManager.Models.Ping;
using HappyTravel.Komoro.UnitTests.Infrastructure;
using System;
using System.IO;
using Xunit;

namespace HappyTravel.Komoro.UnitTests.TravelClick;

public class PingXmlSerializationTests
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

        var fileName = SerializationHelper.SerializeAndSave(data);

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

        var fileName = SerializationHelper.SerializeAndSave(data);

        Assert.True(File.Exists(fileName));
    }
}
