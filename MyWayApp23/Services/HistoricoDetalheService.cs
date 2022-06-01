namespace MyWayApp23.Services;

public class HistoricoDetalheService : IHistoricoDetalheService
{
    private readonly DataContext _context;

    public HistoricoDetalheService(DataContext context)
    {
        _context = context;
    }

    public List<HistoricoDetalhe> GetDetalhes(DateTime data)
    {

        List<HistoricoDetalhe> detalhes = new();

        var historico = _context.HistoricoAssistencias!.ToList();

        foreach (DateTime date in DateHelper.AllDatesInMonth(data.Year, data.Month))
        {
            int total = historico.Where(d => d.Data.Date == date.Date).Count();
            int dep = historico.Where(m => m.Mov == "D").Where(d => d.Data.Date == date.Date).Count();
            int arr = historico.Where(m => m.Mov == "A").Where(d => d.Data.Date == date.Date).Count();

            HistoricoDetalhe detalhe = new()
            {
                Data = DateOnly.FromDateTime(date),
                DiaSemana = date.ToString("ddd", CultureInfo.CreateSpecificCulture("pt-PT")),
                TotalDia = total,
                Dep = dep,
                Arr = arr
            };

            if (total > 0)
            {
                detalhe.DepPercentage = PercentageHelper.PercentageToString(dep, total);
            }

            detalhes.Add(detalhe);
        }

        return detalhes;
    }
}
