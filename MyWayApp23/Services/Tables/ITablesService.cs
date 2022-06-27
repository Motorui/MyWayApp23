namespace MyWayApp23.Services.Tables
{
    public interface ITablesService
    {
        List<TotalByMonthModel> GetTotalByMonth(List<HistoricoAssistencia> historico);
        Dictionary<DateTime, string> GetGrowth(List<HistoricoAssistencia> historico);
    }
}