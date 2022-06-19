namespace MyWayApp23.Services.Historico;

public class HistoricoDetalheHoraService : IHistoricoDetalheHoraService
{
    private readonly DataContext _context;

    public HistoricoDetalheHoraService(DataContext context)
    {
        _context = context;
    }

    public List<HistoricoDetalheHora> GetDetalhesHora(DateTime data)
    {
        List<HistoricoDetalheHora> horas = new();

        var historico = _context.HistoricoAssistencias!.ToList();

        foreach (DateTime date in DateHelper.AllDatesInMonth(data.Year, data.Month))
        {
            List<HistoricoAssistencia>? detalhesData = historico.Where(d => d.Data.Date == date.Date).ToList();
            HistoricoDetalheHora detalhe = new()
            {
                Data = date,
                DiaSemana = date.DayOfWeek,
                TotalDia = detalhesData.Count,
                Zero = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(0)),
                Uma = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(1)),
                Duas = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(2)),
                Tres = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(3)),
                Quatro = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(4)),
                Cinco = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(5)),
                Seis = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(6)),
                Sete = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(7)),
                Oito = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(8)),
                Nove = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(9)),
                Dez = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(10)),
                Onze = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(11)),
                Doze = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(12)),
                Treze = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(13)),
                Quatorze = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(14)),
                Quinze = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(15)),
                Dezaseis = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(16)),
                Dezasete = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(17)),
                Dezoito = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(18)),
                Dezanove = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(19)),
                Vinte = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(20)),
                Vinteeum = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(21)),
                Vinteedois = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(22)),
                Vinteetres = detalhesData.Count(h => h.Data.TimeOfDay.Hours.Equals(23)),
                Manha = detalhesData.Count(h => h.Data.TimeOfDay.Hours >= 4 && h.Data.TimeOfDay.Hours <= 13),
                Tarde = detalhesData.Count(h => h.Data.TimeOfDay.Hours >= 14 && h.Data.TimeOfDay.Hours <= 23),
                Noite = detalhesData.Count(h => h.Data.TimeOfDay.Hours >= 0 && h.Data.TimeOfDay.Hours <= 3) +
                        detalhesData.Count(h => h.Data.TimeOfDay.Hours >= 22 && h.Data.TimeOfDay.Hours <= 23),
            };

            horas.Add(detalhe);
        }

        return horas.Where(t => t.TotalDia > 0).ToList();
    }
}
