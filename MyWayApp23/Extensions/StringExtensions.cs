using System.Text.RegularExpressions;

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

    public static long ConvertToLong(this string? source)
    {
        if (source == null || source.Trim() == "-")
        {
            return TimeSpan.Zero.Ticks;
        }
        else
        {
            return new TimeSpan(int.Parse(source.Split(':')[0]),
                int.Parse(source.Split(':')[1]), 0).Ticks;
        }
    }

    private static readonly Regex sWhitespace = new(@"\s+");
    public static string ReplaceWhitespace(string input, string replacement)
    {
        return sWhitespace.Replace(input, replacement);
    }

    public static string RemoveWhitespace(this string input)
    {
        return sWhitespace.Replace(input, "");
    }

    private static readonly Regex sNonAlphanumeric = new("[^a-zA-Z0-9 -]");
    public static string RemoveNonAlphanumeric(this string input)
    {
        return sNonAlphanumeric.Replace(input, "");
    }
}
