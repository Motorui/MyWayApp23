namespace MyWayApp23.Helpers;

public static class StringHelper
{
    public static double ConvertToDouble(string Value)
    {
        if (Value == null)
        {
            return 0;
        }
        else
        {
            string newValue = Value.Replace(":", ",");
            double OutVal;
            double.TryParse(newValue, out OutVal);

            if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
            {
                return 0;
            }
            return OutVal;
        }
    }
}
