using System.Diagnostics;

namespace MyWayApp23.Services;

public class AssistenciaService : IAssistenciaService
{
    private readonly DataContext _context;

    public AssistenciaService(DataContext context)
    {
        _context = context;
    }

    public List<Assistencia> GetAll()
    {
        List<Assistencia> assistencias;
        try
        {
            assistencias = _context.Assistencias!.ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return assistencias;
    }

    public async Task<Assistencia> GetByIdAsync(Guid id)
    {
        Assistencia assistencia;
        try
        {
            assistencia = await _context.Assistencias!.FirstAsync(a => a.Id == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return assistencia;
    }

    public async Task<bool> CreateAsync(Assistencia assistencia)
    {
        int result;
        try
        {
            if (assistencia == null)
                return false;

            await _context.AddAsync(assistencia);
            result = await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return result > 0;
    }

    public async Task<bool> UpdateAsync(Assistencia assistencia)
    {
        int result;
        try
        {
            if (assistencia == null)
                return false;

            _context.Update(assistencia);
            result = await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return result > 0;
    }

    public async Task<bool> CreateOrUpdateAsync(Assistencia assistencia)
    {
        int result;

        try
        {
            if (assistencia == null)
                return false;

            var exists = await _context.Assistencias!.AsNoTracking().SingleOrDefaultAsync(a =>
                a.Data.Date == assistencia.Data.Date &&
                a.Voo == assistencia.Voo &&
                a.Mov == assistencia.Mov &&
                a.Pax == assistencia.Pax
            );

            if (exists == null)
            {
                await _context.AddAsync(assistencia);
            }
            else
            {
                assistencia.Id = exists.Id;
                _context.Update(assistencia);
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

    public async Task<bool> DeleteAsync(Assistencia assistencia)
    {
        int result;
        try
        {
            if (assistencia == null)
                return false;

            _context.Remove(assistencia);
            result = await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return result > 0;
    }

    public async Task<bool> ExistsAsync(Assistencia assistencia)
    {
        var exists = await _context.Assistencias!.AsNoTracking().SingleOrDefaultAsync(a =>
                a.Data.Date == assistencia.Data.Date &&
                a.Voo == assistencia.Voo &&
                a.Mov == assistencia.Mov &&
                a.Pax == assistencia.Pax
            );

        return exists != null;
    }
}
