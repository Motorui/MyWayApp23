namespace MyWayApp23.Services;

public interface IAssistenciaService
{
    Task<bool> CreateAsync(Assistencia assistencia);
    Task<bool> CreateOrUpdateAsync(Assistencia assistencia);
    Task<bool> DeleteAsync(Assistencia assistencia);
    List<Assistencia> GetAll();
    Task<Assistencia> GetByIdAsync(Guid id);
    List<Assistencia> GetByDate(DateTime date);
    Task<bool> UpdateAsync(Assistencia assistencia);
    Task<Assistencia?> ExistsAsync(Assistencia assistencia);
}