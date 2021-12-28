using System.ComponentModel;

namespace HappyTravel.Komoro.Data.Models.Statics;

public enum NoShowPolicies
{
    [Description("1 night stay")]
    OneNightStay = 1,

    [Description("Full Stay Charged")]
    FullStayCharged = 2
}
