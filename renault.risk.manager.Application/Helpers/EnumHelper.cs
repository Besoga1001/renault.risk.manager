using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace renault.risk.manager.Application.Helpers;

public static class EnumHelper
{
    public static string GetDisplay(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field == null) return "";
        var attribute = field.GetCustomAttribute<DisplayAttribute>();

        return attribute?.Name ?? value.ToString();
    }

    public static string GetDescriptionByDisplay(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field == null) return "";
        var attribute = field.GetCustomAttribute<DisplayAttribute>();

        return attribute?.Description ?? value.ToString();
    }

    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field == null) return "";
        var attribute = field.GetCustomAttribute<DescriptionAttribute>();

        return attribute == null ? value.ToString() : attribute.Description;
    }
}