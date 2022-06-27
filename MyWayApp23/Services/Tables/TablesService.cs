using MudBlazor;
using System;

namespace MyWayApp23.Services.Tables;

public class TablesService : ITablesService
{

    /// <summary>
    /// Retreive Historico de assistencias por mês
    /// </summary>
    /// <param name="historico"></param>
    /// <returns>Lista de totais por mes em cada ano</returns>
    public List<TotalByMonthModel> GetTotalByMonth(List<HistoricoAssistencia> historico)
    {
        List<TotalByMonthModel> result = new();
        result = historico.GroupBy(g => new { Mes = g.Data.Month })
                .Select(x => new TotalByMonthModel
                {
                    Mes = new DateTime(DateTime.UtcNow.Year, x.Key.Mes, 1),
                    Total = x.Count(),
                    DepNotif = x.Count(n => TimeSpan.FromTicks(n.Notif) >= TimeSpan.FromHours(36)
                    && n.Mov == "D"),
                    DepNotNotif = x.Count(n => TimeSpan.FromTicks(n.Notif) < TimeSpan.FromHours(36)
                    && n.Mov == "D"),
                    ArrNotif = x.Count(n => TimeSpan.FromTicks(n.Notif) >= TimeSpan.FromHours(36)
                    && n.Mov == "A"),
                    ArrNotNotif = x.Count(n => TimeSpan.FromTicks(n.Notif) < TimeSpan.FromHours(36)
                    && TimeSpan.FromTicks(n.Notif) >= TimeSpan.FromMinutes(90)
                    && n.Mov == "A"),
                    ArrNotNotif90 = x.Count(n => TimeSpan.FromTicks(n.Notif) < TimeSpan.FromMinutes(90)
                    && n.Mov == "A")
                }).ToList();

        return result;
    }

    public Dictionary<DateTime, string> GetGrowth(List<HistoricoAssistencia> historico)
    {
        Dictionary<DateTime, string> result = new();

        var temp = historico.GroupBy(g => new { Mes = g.Data.Month })
                .Select(x => new
                {
                    Mes = new DateTime(DateTime.UtcNow.Year, x.Key.Mes, 1),
                    Total = x.Count()
                }).ToList();

        for (int i = 0; i < temp.Count; i++)
        {
            double percentage = 0;
            double pastMonth = 0;
            double currentMonth = temp[i].Total;
            if ((i - 1) < 0)
            {
                percentage = 0;
            }
            else
            {
                pastMonth = temp[i - 1].Total;
                percentage = Math.Round((currentMonth - pastMonth) / currentMonth * 100, 2);
            };
                        
            result.Add(temp[i].Mes, percentage.ToString("0.00") + "%");
        }
        return result;
    }
}
