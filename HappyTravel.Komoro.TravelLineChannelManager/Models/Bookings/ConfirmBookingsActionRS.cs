using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings
{
    /// <summary>
    /// Response to the ConfirmBookingsActionRQ request. Your system informs the channel manager system of the delivery status of the acknowledgment. 
    /// If the confirmation is accepted by your system, then you need to return: Success = true
    /// </summary>
    internal record ConfirmBookingsActionRS : BaseResponse
    {
    }
}
