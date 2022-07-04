namespace MyWayApp23.Services.Charts;

public class ChartServiceBase
{
    public static bool HasItems(List<decimal> data)
    {
        var result = data.Find(x => x > 0);
        if (result == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static string RandomRgbaColor(double alpha)
    {
        var random = new Random();
        string color = $"rgba({random.Next(0, 255)},{random.Next(0, 255)},{random.Next(0, 255)},{alpha})";
        return color;
    }

    public static Dictionary<string, List<decimal>> FillDemandByWeekDay(List<DemandByWeekdayModel> DemandByWeekday)
    {
        Dictionary<string, List<decimal>> DemandByWeekDayData = new();
        if (DemandByWeekday.Select(d => d.Jan).Count() > 0)
        {
            DemandByWeekDayData.Add("Jan", DemandByWeekday.Select(d => d.Jan).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Fev).ToList()))
        {
            DemandByWeekDayData.Add("Fev", DemandByWeekday.Select(d => d.Fev).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Mar).ToList()))
        {
            DemandByWeekDayData.Add("Mar", DemandByWeekday.Select(d => d.Mar).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Abr).ToList()))
        {
            DemandByWeekDayData.Add("Abr", DemandByWeekday.Select(d => d.Abr).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Mai).ToList()))
        {
            DemandByWeekDayData.Add("Mai", DemandByWeekday.Select(d => d.Mai).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Jun).ToList()))
        {
            DemandByWeekDayData.Add("Jun", DemandByWeekday.Select(d => d.Jun).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Jul).ToList()))
        {
            DemandByWeekDayData.Add("Jul", DemandByWeekday.Select(d => d.Jul).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Ago).ToList()))
        {
            DemandByWeekDayData.Add("Ago", DemandByWeekday.Select(d => d.Ago).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Set).ToList()))
        {
            DemandByWeekDayData.Add("Set", DemandByWeekday.Select(d => d.Set).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Out).ToList()))
        {
            DemandByWeekDayData.Add("Out", DemandByWeekday.Select(d => d.Out).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Nov).ToList()))
        {
            DemandByWeekDayData.Add("Nov", DemandByWeekday.Select(d => d.Nov).ToList());
        }
        if (HasItems(DemandByWeekday.Select(d => d.Dez).ToList()))
        {
            DemandByWeekDayData.Add("Dez", DemandByWeekday.Select(d => d.Dez).ToList());
        }

        return DemandByWeekDayData;
    }
}