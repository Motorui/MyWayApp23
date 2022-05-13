﻿namespace MyWayApp23.Services
{
    public interface IHistoricoService
    {
        Task<bool> CreateAsync(HistoricoAssistencia historico);
        Task<bool> CreateOrUpdateAsync(HistoricoAssistencia historico);
        Task<bool> DeleteAsync(HistoricoAssistencia historico);
        Task<bool> ExistsAsync(HistoricoAssistencia historico);
        List<HistoricoAssistencia> GetAll();
        Task<HistoricoAssistencia> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(HistoricoAssistencia historico);
    }
}