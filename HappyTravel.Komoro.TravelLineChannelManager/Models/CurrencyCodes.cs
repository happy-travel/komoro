using System.Runtime.Serialization;

namespace HappyTravel.Komoro.TravelLineChannelManager.Models;

internal enum CurrencyCodes
{
    [EnumMember(Value = "AMD")]
    Amd = 51,

    [EnumMember(Value = "AZN")]
    Azn = 944,

    [EnumMember(Value = "BGN")]
    Bgn = 975,

    [EnumMember(Value = "BYN")]
    Byn = 933,

    [EnumMember(Value = "CAD")]
    Cad = 124,

    [EnumMember(Value = "CHF")]
    Chf = 756,

    [EnumMember(Value = "CNY")]
    Cny = 156,

    [EnumMember(Value = "EUR")]
    Eur = 978,

    [EnumMember(Value = "GBR")]
    Gbr = 826,

    [EnumMember(Value = "INR")]
    Inr = 356,

    [EnumMember(Value = "KGS")]
    Kgs = 417,

    [EnumMember(Value = "KRW")]
    Krw = 410,

    [EnumMember(Value = "KZT")]
    Kzt = 398,

    [EnumMember(Value = "MDL")]
    Mdl = 498,

    [EnumMember(Value = "NOK")]
    Nok = 578,

    [EnumMember(Value = "PLN")]
    Pln = 985,

    [EnumMember(Value = "RUB")]
    Rub = 643,

    [EnumMember(Value = "TJS")]
    Tjs = 972,

    [EnumMember(Value = "UAN")]
    Uan = 980,  // TODO: Fix it

    [EnumMember(Value = "USD")]
    Usd = 840,

    [EnumMember(Value = "UZS")]
    Uzs = 860
}
