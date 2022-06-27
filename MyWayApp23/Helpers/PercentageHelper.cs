namespace MyWayApp23.Helpers;

public static class PercentageHelper
{
    public static string PercentageToString(double value, double total)
    {
        double result = value / total;
        return result.ToString("P", CultureInfo.InvariantCulture);
    }

    public static double PercentageToDouble(int? value, int? total)
    {
        //percentage = (yourNumber / totalNumber) * 100;
        double doubleValue = Convert.ToDouble(value);
        double doubleTotal = Convert.ToDouble(total);
        if (value > 0 && total > 0)
        {
            return (doubleValue / doubleTotal) * 100;
        }
        else
        {
            return 0;
        }

    }

    public static string GetPercentage(decimal value, decimal total)
    {
        if (total == 0)
        {
            return "0%";
        }
        return (value * 100 / total).ToString("0.00") + "%";
    }
}
