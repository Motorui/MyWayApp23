namespace MyWayApp23.Services
{
    public interface IHistoricoService
    {
        Task<bool> CreateAsync(HistoricoAssistencia historico);
        Task<bool> CreateOrUpdateAsync(HistoricoAssistencia historico);
        Task<bool> DeleteAsync(HistoricoAssistencia historico);
        Task<HistoricoAssistencia?> ExistsAsync(HistoricoAssistencia historico);
        List<HistoricoAssistencia> GetAll();
        Task<HistoricoAssistencia> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(HistoricoAssistencia historico);
        List<HistoricoDetalhe> Teste(DateTime data);
    }
}