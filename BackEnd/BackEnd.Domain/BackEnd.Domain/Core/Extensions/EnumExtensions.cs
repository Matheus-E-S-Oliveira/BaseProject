using System.Reflection;

using BackEnd.Domain.Core.Attributes;

namespace BackEnd.Domain.Core.Extensions;

public static class EnumExtensions
{
    public static bool IsNotSet<TEnum>(this TEnum value)
        where TEnum : struct, Enum
    {
        return Convert.ToInt32(value) == 0;
    }

    public static string GetStringValue<TEnum>(this TEnum value)
        where TEnum : struct, Enum
    {
        var member = typeof(TEnum)
                .GetMember(value.ToString())
                .First();

        var attribute = member
            .GetCustomAttributes<StringValueAttribute>()
            .First();

        return attribute.Value;
    }
}
