namespace MyWayApp23.Helpers;

public static class DateHelper
{
    public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
    {
        int days = DateTime.DaysInMonth(year, month);
        for (int day = 1; day <= days; day++)
        {
            yield return new DateTime(year, month, day);
        }
    }

    public static DateTime? ConvertDateTimeFromStrings(string datetime)
    {
        if (datetime == null)
            return null;

        try
        {
            return DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm:ss",
                                    new CultureInfo("pt-PT"),
                                    DateTimeStyles.None);
        }
        catch (Exception)
        {
            return null;
        }



    }
}
