using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Gradebook.Domain;

public static class Extensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
                       .GetField(enumValue.ToString())
                       .GetCustomAttribute<DisplayAttribute>().Name;
    }
}
