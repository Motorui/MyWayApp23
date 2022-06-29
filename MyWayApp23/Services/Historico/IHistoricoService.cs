namespace MyWayApp23.Services.Historico;

public interface IHistoricoService
{
    Task<bool> CreateAsync(HistoricoAssistencia historico);

    Task<bool> CreateOrUpdateAsync(HistoricoAssistencia historico);

    Task<bool> DeleteAsync(HistoricoAssistencia historico);

    Task<HistoricoAssistencia?> ExistsAsync(HistoricoAssistencia historico);

    Task<List<HistoricoAssistencia>> FilterDataAsync(int year, string uh, int month);

    List<HistoricoAssistencia> GetAll();

    Task<HistoricoAssistencia> GetByIdAsync(string id);

    Task<List<HistoricoAssistencia>> GetByYearAsync(int year);

    Task<bool> UpdateAsync(HistoricoAssistencia historico);
}