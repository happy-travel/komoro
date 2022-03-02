using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Ping
{
    /// <summary>
    /// The Ping request is used to determine the availability of a web service. This may be used for alerting purposes to detect when the service
    /// is not available so that message flow can be halted until it recovers. Both TravelClick and the OTA Partner shall implement this service call
    /// so that either system can verify the status of the other.
    /// The OTA_PingRQ only contains a single child element: EchoData. It is expected that any text content within this element will be returned in the
    /// corresponding response. No authentication is required to make this request.
    /// </summary>
    [XmlRoot(ElementName = "OTA_PingRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public record OtaPingRQ
    {
        [XmlAttribute]
        public string Version { get; init; } = string.Empty;

        [XmlAttribute]
        public DateTime TimeStamp { get; init; }

        /// <summary>
        /// Contains string that shall be echoed in the response.
        /// </summary>
        public string EchoData { get; init; } = string.Empty;
    }
}
