﻿namespace MyWayApp23.Services;

public class DataTableConverter : IDataTableConverter
{
    private readonly List<string> assistencias = new()
        {
            "Aeroporto", "Msg", "Notif", "Data", "Voo", "Mov", "Orig Dest", "Pax", "SSR", "AC", "Stand", "Exit", "Ck In", "Gate", "Transferencia"
        };

    private readonly List<string> historico = new()
        {
            "Tipo Msg", "Aeroporto", "Notif", "Data Voo", "Hora Voo", "Data Contacto", "Hora Contacto", "Data Calcos", "Hora Calcos",
            "Data Inicio Assistencia", "Hora Inicio Assistencia", "Data Fim Assistencia", "Hora Fim Assistencia", "Voo", "Mov", "Orig Dest",
            "Pax", "SSR", "AC", "Stand", "Exit", "Ck In", "Gate", "Transferencia", "Equipamentos", "Justificacao Incumprimento"
        };

    public string ReturnFileType(DataTable tbl)
    {
        List<string> columns = tbl.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToList();

        if (columns.SequenceEqual(assistencias))
        {
            return "assistencias";
        }
        else if (columns.SequenceEqual(historico))
        {
            return "historico";
        }
        else
        {
            return string.Empty;
        }
    }

    public List<Assistencia> ConvertDataTableToAssistencias(DataTable tbl)
    {
        List<Assistencia> results = new();

        // iterate over your data table
        foreach (DataRow row in tbl.Rows)
        {
            Assistencia convertedObject = ConvertRowToAssistencia(row);
            results.Add(convertedObject);
        }

        return results;
    }

    public Assistencia ConvertRowToAssistencia(DataRow row)
    {
        Assistencia result = new()
        {
            Id = Guid.NewGuid(),
            Aeroporto = row["Aeroporto"].ToString()!,
            Msg = row["Msg"].ToString()!,
            Notif = row["Notif"].ToString()!,
            Data = DateTime.Parse(row["Data"].ToString()!),
            Voo = row["Voo"].ToString()!,
            Mov = row["Mov"].ToString()!,
            OrigDest = row["Orig Dest"].ToString(),
            Pax = row["Pax"].ToString()!,
            SSR = row["SSR"].ToString()!,
            AC = row["AC"].ToString(),
            Stand = row["Stand"].ToString(),
            Exit = row["Exit"].ToString(),
            CkIn = row["Ck In"].ToString(),
            Gate = row["Gate"].ToString(),
            Transferencia = row["Transferencia"].ToString(),
            HoraEmbarque = null,
            SaidaStaging = null,
            EstimaApresentacao = null
        };

        return result;
    }

    public List<HistoricoAssistencia> ConvertDataTableToHistorico(DataTable tbl)
    {
        List<HistoricoAssistencia> results = new();

        // iterate over your data table
        foreach (DataRow row in tbl.Rows)
        {
            HistoricoAssistencia convertedObject = ConvertRowToHistorico(row);
            results.Add(convertedObject);
        }

        return results;
    }

    public HistoricoAssistencia ConvertRowToHistorico(DataRow row)
    {
        HistoricoAssistencia result = new()
        {
            Id = Guid.NewGuid(),
            Aeroporto = row["Aeroporto"].ToString()!,
            Msg = row["Msg"].ToString()!,
            Notif = row["Notif"].ToString()!,
            Data = DateTime.Parse(row["Data"].ToString()!),
            Voo = row["Voo"].ToString()!,
            Mov = row["Mov"].ToString()!,
            OrigDest = row["Orig Dest"].ToString(),
            Pax = row["Pax"].ToString()!,
            SSR = row["SSR"].ToString()!,
            AC = row["AC"].ToString(),
            Stand = row["Stand"].ToString(),
            Exit = row["Exit"].ToString(),
            CkIn = row["Ck In"].ToString(),
            Gate = row["Gate"].ToString(),
            Transferencia = row["Transferencia"].ToString()
        };

        return result;
    }
}