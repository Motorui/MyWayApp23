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
        List<string> _mangas = TipoStand("JETBRIDGE");
        List<string> _remotos = TipoStand("REMOTE");
        List<HistoricoDetalhe> detalhes = new();

        var historico = _context.HistoricoAssistencias!.ToList();

        foreach (DateTime date in DateHelper.AllDatesInMonth(data.Year, data.Month))
        {

            int total = historico.Where(d => d.Data.Date == date.Date).Count();
            int dep = historico.Where(m => m.Mov == "D").Where(d => d.Data.Date == date.Date).Count();
            int arr = historico.Where(m => m.Mov == "A").Where(d => d.Data.Date == date.Date).Count();
            int jetbridge = historico.Where(m => _mangas.Contains(m.Stand!)).Where(d => d.Data.Date == date.Date).Count();
            int remoto = historico.Where(m => _remotos.Contains(m.Stand!)).Where(d => d.Data.Date == date.Date).Count();
            //int mais36 = historico.Where(m => m.Notif >= 36).Where(d => d.Data.Date == date.Date).Count();

            HistoricoDetalhe detalhe = new()
            {
                Data = DateOnly.FromDateTime(date),
                DiaSemana = date.ToString("ddd", CultureInfo.CreateSpecificCulture("pt-PT")),
                TotalDia = total,
                Dep = dep,
                Arr = arr,
                JetBridge = jetbridge,
                Remote = remoto,
                Mais36 = 0,
            };

            if (total > 0)
            {
                detalhe.DepPercentage = PercentageHelper
                    .PercentageToString(dep, total);
                detalhe.ArrPercentage = PercentageHelper
                    .PercentageToString(arr, total);
                detalhe.JetBridgePercentage = PercentageHelper
                    .PercentageToString(jetbridge, total);
                detalhe.RemotePercentage = PercentageHelper
                    .PercentageToString(remoto, total);
            }

            detalhes.Add(detalhe);
        }

        return detalhes.Where(t => t.TotalDia > 0).ToList();
    }

    private List<string> TipoStand(string tipo)
    {
        return _context.Stands!.Where(t => t.Tipo == tipo).Select(m => m.Numero).ToList();
    }
}
