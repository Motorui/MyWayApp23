using PSC.Blazor.Components.Chartjs.Models.Line;

namespace MyWayApp23.Services.Charts;

public interface IChartService
{
    LineChartConfig GetPaxDemandData(List<HistoricoAssistencia> historico);
    LineChartConfig GetDemandByShiftData(List<HistoricoAssistencia> historico);
}