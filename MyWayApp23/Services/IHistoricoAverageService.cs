namespace MyWayApp23.Services
{
    public interface IHistoricoAverageService
    {
        List<HistoricoAverage> GetAvgArr(DateTime data);
        List<HistoricoAverage> GetAvgAssistencias(DateTime data);
        List<HistoricoAverage> GetAvgDep(DateTime data);
        List<HistoricoAverage> GetAvgDuracao(DateTime data);
        List<HistoricoAverage> GetAvgJetBridge(DateTime data);
        List<HistoricoAverage> GetAvgRemote(DateTime data);
    }
}