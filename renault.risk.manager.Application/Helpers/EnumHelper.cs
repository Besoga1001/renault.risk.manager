using System.ComponentModel;
using System.Reflection;

namespace renault.risk.manager.Application.Helpers;

public static class EnumHelper
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field == null) return "";
        var attribute = field.GetCustomAttribute<DescriptionAttribute>();

        return attribute == null ? value.ToString() : attribute.Description;
    }
}