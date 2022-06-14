namespace MyWayApp23.Services.Historico;

public class HistoricoAverageService : IHistoricoAverageService
{
    private readonly DataContext _context;

    public HistoricoAverageService(DataContext context)
    {
        _context = context;
    }

    public List<HistoricoAverage> GetAvgTotal(DateTime data)
    {
        DateTime currentDate = new(data.Year, 1, 1);
        DateTime endDate = new(data.Year, 12, 1);

        var historico = _context.HistoricoAssistencias!.Where(d => d.Data.Year.Equals(data.Year)).ToList();

        List<HistoricoAverage> result = FilterData(historico, currentDate, endDate);

        return result;
    }

    public List<HistoricoAverage> GetAvgArrDep(DateTime data, string mov)
    {
        DateTime currentDate = new(data.Year, 1, 1);
        DateTime endDate = new(data.Year, 12, 1);

        var historico = _context.HistoricoAssistencias!.Where(d => d.Data.Year.Equals(data.Year) && d.Mov.Equals(mov)).ToList();

        List<HistoricoAverage> result = FilterData(historico, currentDate, endDate);

        return result;
    }

    public List<HistoricoAverage> GetAvgRemJet(DateTime data, string tipo)
    {
        DateTime currentDate = new(data.Year, 1, 1);
        DateTime endDate = new(data.Year, 12, 1);

        List<string> _tipoStand = TipoStand(tipo);

        var historico = _context.HistoricoAssistencias!.Where(d => d.Data.Year.Equals(data.Year) && _tipoStand.Contains(d.Stand!)).ToList();

        List<HistoricoAverage> result = FilterData(historico, currentDate, endDate);

        return result;
    }

    public List<HistoricoAverageTime> GetAvgTime(DateTime data)
    {
        DateTime currentDate = new(data.Year, 1, 1);
        DateTime endDate = new(data.Year, 12, 1);

        var historico = _context.HistoricoAssistencias!.Where(d => d.Data.Year.Equals(data.Year)).ToList();

        List<HistoricoAverageTime> result = FilterDataTime(historico, currentDate, endDate);

        return result;
    }

    private static List<HistoricoAverage> FilterData(List<HistoricoAssistencia> historico,
        DateTime currentDate, DateTime endDate)
    {
        List<HistoricoAverage> result = new();

        var filter = historico.GroupBy(r => new { Dia = r.Data.Date })
            .Select(x => new { x.Key.Dia, NumResults = x.Count() }).ToList();

        while (currentDate <= endDate)
        {
            HistoricoAverage average = new()
            {
                Data = currentDate,
                Mes = currentDate.ToString("MMM", CultureInfo.CreateSpecificCulture("pt-PT")),
                Seg = (int)filter.Where(h => h.Dia.Month == currentDate.Month && h.Dia.DayOfWeek
                    .Equals(DayOfWeek.Monday)).Select(n => n.NumResults).DefaultIfEmpty(0).Average(),
                Ter = (int)filter.Where(h => h.Dia.Month == currentDate.Month && h.Dia.DayOfWeek
                .Equals(DayOfWeek.Tuesday)).Select(n => n.NumResults).DefaultIfEmpty(0).Average(),
                Qua = (int)filter.Where(h => h.Dia.Month == currentDate.Month && h.Dia.DayOfWeek
                .Equals(DayOfWeek.Wednesday)).Select(n => n.NumResults).DefaultIfEmpty(0).Average(),
                Qui = (int)filter.Where(h => h.Dia.Month == currentDate.Month && h.Dia.DayOfWeek
                .Equals(DayOfWeek.Thursday)).Select(n => n.NumResults).DefaultIfEmpty(0).Average(),
                Sex = (int)filter.Where(h => h.Dia.Month == currentDate.Month && h.Dia.DayOfWeek
                .Equals(DayOfWeek.Friday)).Select(n => n.NumResults).DefaultIfEmpty(0).Average(),
                Sab = (int)filter.Where(h => h.Dia.Month == currentDate.Month && h.Dia.DayOfWeek
                .Equals(DayOfWeek.Saturday)).Select(n => n.NumResults).DefaultIfEmpty(0).Average(),
                Dom = (int)filter.Where(h => h.Dia.Month == currentDate.Month && h.Dia.DayOfWeek
                .Equals(DayOfWeek.Sunday)).Select(n => n.NumResults).DefaultIfEmpty(0).Average(),
            };

            result.Add(average);

            currentDate = currentDate.AddMonths(1);
        }

        return result;
    }

    private static List<HistoricoAverageTime> FilterDataTime(List<HistoricoAssistencia> historico,
    DateTime currentDate, DateTime endDate)
    {
        List<HistoricoAverageTime> result = new();

        TimeOnly times = TimeOnly.FromTimeSpan(new TimeSpan(0));

        while (currentDate <= endDate)
        {
            var filter = historico.Where(d => d.Data.Date == currentDate.Date).ToList();

            HistoricoAverageTime average = new()
            {
                Mes = currentDate.ToString("MMM", CultureInfo.CreateSpecificCulture("pt-PT")),
                Seg = TimeAverage(filter.Where(h => h.Data.Month == currentDate.Month && h.Data.DayOfWeek
                .Equals(DayOfWeek.Monday)).ToList()),
                Ter = TimeAverage(filter.Where(h => h.Data.Month == currentDate.Month && h.Data.DayOfWeek
                .Equals(DayOfWeek.Tuesday)).ToList()),
                Qua = TimeAverage(filter.Where(h => h.Data.Month == currentDate.Month && h.Data.DayOfWeek
                .Equals(DayOfWeek.Wednesday)).ToList()),
                Qui = TimeAverage(filter.Where(h => h.Data.Month == currentDate.Month && h.Data.DayOfWeek
                .Equals(DayOfWeek.Thursday)).ToList()),
                Sex = TimeAverage(filter.Where(h => h.Data.Month == currentDate.Month && h.Data.DayOfWeek
                .Equals(DayOfWeek.Friday)).ToList()),
                Sab = TimeAverage(filter.Where(h => h.Data.Month == currentDate.Month && h.Data.DayOfWeek
                .Equals(DayOfWeek.Saturday)).ToList()),
                Dom = TimeAverage(filter.Where(h => h.Data.Month == currentDate.Month && h.Data.DayOfWeek
                .Equals(DayOfWeek.Sunday)).ToList())
            };

            result.Add(average);

            currentDate = currentDate.AddMonths(1);
        }

        return result;
    }

    private List<string> TipoStand(string tipo)
    {
        return _context.Stands!.Where(t => t.Tipo == tipo).Select(m => m.Numero).ToList();
    }

    private static double TimeAverage(List<HistoricoAssistencia> filter)
    {
        TimeOnly average = TimeOnly.FromTimeSpan(new TimeSpan(0));

        List<TimeSpan> media = new();
        foreach (var row in filter)
        {
            TimeSpan fim = new();
            if (row.Fim != null) { fim = row.Fim.Value.TimeOfDay; }
            TimeSpan inicio = new();
            if (row.Inicio != null) { inicio = row.Inicio.Value.TimeOfDay; }

            if (fim > inicio)
            {
                TimeSpan m = fim - inicio;
                media.Add(m);
            }
        }

        if (media.Count > 0)
        {
            double doubleAverageTicks = media.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);

            average = TimeOnly.FromTimeSpan(new TimeSpan(longAverageTicks));
        }

        return average.ToTimeSpan().TotalMinutes;
    }
}
