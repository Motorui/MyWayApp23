namespace MyWayApp23.Helpers;

public static class PercentageHelper
{
    public static string PercentageToString(double value, double total)
    {
        double result = value / total;
        return result.ToString("P", CultureInfo.InvariantCulture);
    }
}
