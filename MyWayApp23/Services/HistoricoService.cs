﻿using System.Diagnostics;

namespace MyWayApp23.Services;

public class HistoricoService : IHistoricoService
{
    private readonly DataContext _context;

    public HistoricoService(DataContext context)
    {
        _context = context;
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

    public async Task<HistoricoAssistencia> GetByIdAsync(Guid id)
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
                historico.Id = exists.Id;

                _context.Entry(exists).State = EntityState.Detached;

                _context.Update(historico);
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

        return exists; ;

    }

    public List<HistoricoDetalhe> Teste(DateTime data)
    {

        List<HistoricoDetalhe> detalhes = new();

        var historico = GetAll();

        foreach (DateTime date in AllDatesInMonth(data.Year, data.Month))
        {
            int total = historico.Where(d => d.Data.Date == date.Date).Count();
            int dep = historico.Where(m => m.Mov == "D").Where(d => d.Data.Date == date.Date).Count();
            int arr = historico.Where(m => m.Mov == "A").Where(d => d.Data.Date == date.Date).Count();

            HistoricoDetalhe detalhe = new()
            {
                Data = DateOnly.FromDateTime(date),
                DiaSemana = date.ToString("ddd", CultureInfo.CreateSpecificCulture("pt-PT")),
                TotalDia = total,
                Dep = dep,
                Arr = arr
            };

            if (total > 0)
            {
                detalhe.DepPercentage = PercentageCalc(dep, total);
            }

            detalhes.Add(detalhe);
        }


        return detalhes;
    }

    public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
    {
        int days = DateTime.DaysInMonth(year, month);
        for (int day = 1; day <= days; day++)
        {
            yield return new DateTime(year, month, day);
        }
    }

    public string PercentageCalc(double value, double total)
    {
        double result = value / total;
        return result.ToString("P", CultureInfo.InvariantCulture);
    }
}