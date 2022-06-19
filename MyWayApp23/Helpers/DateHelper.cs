namespace MyWayApp23.Helpers;
public static class DateHelper
{
    static CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-PT");
    static DateTimeStyles styles;
    static DateTime dateResult;
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
        culture = CultureInfo.CreateSpecificCulture("pt-PT");
        styles = DateTimeStyles.None;

        if (datetime == null)
            return null;

        try
        {
            if (DateTime.TryParse(datetime, culture, styles, out dateResult))
                return dateResult;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static long SubtractFromDates(DateTime? fim, DateTime? inicio)
    {
        DateTime f;
        DateTime i;
        if (fim != null && inicio != null)
        {
            f = (DateTime)fim;
            i = (DateTime)inicio;

            return f.Subtract(i).Ticks;
        }
        return TimeSpan.Zero.Ticks;
    }
}
