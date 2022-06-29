using EFCore.BulkExtensions;
using System.Diagnostics;

namespace MyWayApp23.Services.Historico;

public class HistoricoService : IHistoricoService
{
    private readonly DataContext _context;

    public HistoricoService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(HistoricoAssistencia historico)
    {
        int result;
        try
        {
            if (historico == null)
                return false;

            await _context.AddAsync(historico);
            result = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return result > 0;
    }

    public async Task<bool> CreateOrUpdateAsync(HistoricoAssistencia historico)
    {
        int result;

        try
        {
            if (historico == null)
                return false;

            var exists = await ExistsAsync(historico);

            if (exists != null)
            {
                _context.Entry(exists).CurrentValues.SetValues(historico);
                //historico.Id = exists.Id;
                //_context.Entry(exists).State = EntityState.Detached;
                //_context.Update(historico);
            }
            else
            {
                await _context.AddAsync(historico);
            }

            result = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return result > 0;
    }

    public async Task<bool> DeleteAsync(HistoricoAssistencia historico)
    {
        int result;
        try
        {
            if (historico == null)
                return false;

            _context.Remove(historico);
            result = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return result > 0;
    }

    public async Task<HistoricoAssistencia?> ExistsAsync(HistoricoAssistencia historico)
    {
        var exists = await _context.HistoricoAssistencias!.AsNoTracking().SingleOrDefaultAsync(a =>
                a.Aeroporto == historico.Aeroporto &&
                a.Data.Date == historico.Data.Date &&
                a.Voo == historico.Voo &&
                a.Mov == historico.Mov &&
                a.Pax == historico.Pax
            );

        return exists;
    }

    public async Task<List<HistoricoAssistencia>> FilterDataAsync(int year, string uh, int month)
    {
        List<HistoricoAssistencia> historicos;
        try
        {
            if (month == 0)
            {
                historicos = await _context.HistoricoAssistencias!.AsNoTracking().Where(a =>
                    a.Data.Year == year &&
                    a.Aeroporto.ToUpper() == uh.ToUpper()
                ).ToListAsync();
            }
            else
            {
                historicos = await _context.HistoricoAssistencias!.AsNoTracking().Where(a =>
                    a.Data.Year == year &&
                    a.Data.Month == month &&
                    a.Aeroporto.ToUpper() == uh.ToUpper()
                ).ToListAsync();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return historicos;
    }

    public List<HistoricoAssistencia> GetAll()
    {
        List<HistoricoAssistencia> historicos;
        try
        {
            historicos = _context.HistoricoAssistencias!.ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return historicos;
    }

    public async Task<HistoricoAssistencia> GetByIdAsync(string id)
    {
        HistoricoAssistencia historico;
        try
        {
            historico = await _context.HistoricoAssistencias!
                .FirstAsync(a => a.Id == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return historico;
    }

    public async Task<List<HistoricoAssistencia>> GetByYearAsync(int year)
    {
        List<HistoricoAssistencia> historicos;
        try
        {
            historicos = await _context.HistoricoAssistencias!
                .Where(d => d.Data.Year.Equals(year)).ToListAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return historicos;
    }

    public async Task<bool> UpdateAsync(HistoricoAssistencia historico)
    {
        int result;
        try
        {
            if (historico == null)
                return false;

            _context.Update(historico);
            result = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return result > 0;
    }
}