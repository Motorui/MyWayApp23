using System.Linq;

namespace MyWayApp23.Services;

public class HistoricoAverageService : IHistoricoAverageService
{
    private readonly DataContext _context;

    public HistoricoAverageService(DataContext context)
    {
        _context = context;
    }

    public List<HistoricoAverage> GetAvgDep(DateTime data)
    {
        List<HistoricoAverage> result = new();
        var historico = _context.HistoricoAssistencias!.Where(d => d.Data.Year == data.Year).ToList();

        for (int i = 1; i < 12; i++)
        {
            DateTime month = new(data.Year, i, 1);

            var detalhesData = historico
                .Where(d => d.Data.Month == month.Month && d.Mov == "D")
                .ToList();

            if (detalhesData.Count() > 0)
            {
                HistoricoAverage average = new()
                {
                    Mes = month.ToString("MMM", CultureInfo.CreateSpecificCulture("pt-PT")),
                    Seg = (int)detalhesData.Where(h => h.Data.DayOfWeek.Equals(DayOfWeek.Monday))
                    .GroupBy(p => p.Data.Day).Select(g => new { count = g.Count() }).Average(c => c.count),
                    Ter = (int)detalhesData.Where(h => h.Data.DayOfWeek.Equals(DayOfWeek.Tuesday))
                    .GroupBy(p => p.Data.Day).Select(g => new { count = g.Count() }).Average(c => c.count),
                    Qua = (int)detalhesData.Where(h => h.Data.DayOfWeek.Equals(DayOfWeek.Wednesday))
                    .GroupBy(p => p.Data.Day).Select(g => new { count = g.Count() }).Average(c => c.count),
                    Qui = (int)detalhesData.Where(h => h.Data.DayOfWeek.Equals(DayOfWeek.Thursday))
                    .GroupBy(p => p.Data.Day).Select(g => new { count = g.Count() }).Average(c => c.count),
                    Sex = (int)detalhesData.Where(h => h.Data.DayOfWeek.Equals(DayOfWeek.Friday))
                    .GroupBy(p => p.Data.Day).Select(g => new { count = g.Count() }).Average(c => c.count),
                    Sab = (int)detalhesData.Where(h => h.Data.DayOfWeek.Equals(DayOfWeek.Saturday))
                    .GroupBy(p => p.Data.Day).Select(g => new { count = g.Count() }).Average(c => c.count),
                    Dom = (int)detalhesData.Where(h => h.Data.DayOfWeek.Equals(DayOfWeek.Sunday))
                    .GroupBy(p => p.Data.Day).Select(g => new { count = g.Count() }).Average(c => c.count)
                };

                result.Add(average);
            }

        }

        return result;
    }

    public List<HistoricoAverage> GetAvgArr(DateTime data)
    {
        return new List<HistoricoAverage>();
    }

    public List<HistoricoAverage> GetAvgRemote(DateTime data)
    {
        return new List<HistoricoAverage>();
    }

    public List<HistoricoAverage> GetAvgJetBridge(DateTime data)
    {
        return new List<HistoricoAverage>();
    }

    public List<HistoricoAverage> GetAvgDuracao(DateTime data)
    {
        return new List<HistoricoAverage>();
    }

    public List<HistoricoAverage> GetAvgAssistencias(DateTime data)
    {
        return new List<HistoricoAverage>();
    }
}
