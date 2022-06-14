namespace MyWayApp23.Services.Historico;

public interface IHistoricoAverageService
{
    List<HistoricoAverage> GetAvgTotal(DateTime data);
    List<HistoricoAverage> GetAvgArrDep(DateTime data, string mov);
    List<HistoricoAverage> GetAvgRemJet(DateTime data, string tipo);
    List<HistoricoAverageTime> GetAvgTime(DateTime data);
}