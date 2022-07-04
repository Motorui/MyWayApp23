using PSC.Blazor.Components.Chartjs.Models.Line;

namespace MyWayApp23.Services.Charts;

public interface IChartService
{
    LineChartConfig GetPaxDemandData(List<HistoricoAssistencia> historico);

    LineChartConfig GetDemandByShiftData(List<HistoricoAssistencia> historico);

    LineChartConfig GetDemandByWeekdayData(List<HistoricoAssistencia> historico);

    LineChartConfig GetRemoteByWeekdayData(List<HistoricoAssistencia> historico);

    LineChartConfig GetPreNotificationData(List<HistoricoAssistencia> historico);
}