namespace MyWayApp23.Extensions;

public static class StringExtensions
{
    public static bool ContainsCaseInsensitive(this string source, string substring)
    {
        return source?.IndexOf(substring, StringComparison.OrdinalIgnoreCase) > -1;
    }

    public static double ConvertToDouble(this string source)
    {
        if (source == null)
        {
            return 0;
        }
        else
        {
            string newValue = source.Replace(":", ",");
            _ = double.TryParse(newValue, out double OutVal);

            if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
            {
                return 0;
            }
            return OutVal;
        }
    }
}
