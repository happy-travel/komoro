using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace HappyTravel.Komoro.Common.Infrastructure.Extensions;

public static class EnumExtensions
{
    public static string GetEnumMember(this Enum value)
    {
        FieldInfo? fileInfo = value.GetType().GetField(value.ToString());
        var members = fileInfo?.GetCustomAttributes(typeof(EnumMemberAttribute), false) ?? Array.Empty<EnumMemberAttribute>();

        if (members is EnumMemberAttribute[] attributes && attributes.Length > 0)
            return attributes[0].Value ?? value.ToString();
        else
            return value.ToString();
    }


    public static string GetDescription(this Enum value)
    {
        FieldInfo? fileInfo = value.GetType().GetField(value.ToString());
        var members = fileInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false) ?? Array.Empty<DescriptionAttribute>();

        if (members is DescriptionAttribute[] attributes && attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }
}
