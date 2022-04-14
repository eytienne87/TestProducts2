using System.Reflection;

namespace TestProducts2.Common
{
    public static class Helper
    {
        public static object? GetDynamicValue(object source, string propertyName)
        {
            if (propertyName.Contains("."))
            {
                List<string> subs = propertyName.Split('.').ToList();

                PropertyInfo? property = source.GetType().GetProperty(subs[0]);
                object? value = null;
                if (property != null)
                    value = property.GetValue(source, null);
                return value != null ? GetDynamicValue(value, string.Join(".", subs.Skip(1))) : null;
            }
            else
            {
                PropertyInfo? property = source.GetType().GetProperty(propertyName);
                object? value = null;
                if (property != null)
                    value = property.GetValue(source, null);
                return value;
            }
        }
    }
}
