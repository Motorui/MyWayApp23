using System.Globalization;

namespace MyWayApp23.Services;

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
            Msg = row["Tipo Msg"].ToString()!,
            Aeroporto = row["Aeroporto"].ToString()!,
            Notif = row["Notif"].ToString()!,
            Data = DateTime.ParseExact(row["Data Voo"].ToString()! + " " + row["Hora Voo"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
            Contacto = ConvertDateTimeFromStrings(row["Data Contacto"].ToString()! + " " + row["Hora Contacto"].ToString()!),
            Calcos = ConvertDateTimeFromStrings(row["Data Calcos"].ToString()! + " " + row["Hora Calcos"].ToString()!),
            Inicio = ConvertDateTimeFromStrings(row["Data Inicio Assistencia"].ToString()! + " " + row["Hora Inicio Assistencia"].ToString()!),
            Fim = ConvertDateTimeFromStrings(row["Data Fim Assistencia"].ToString()! + " " + row["Hora Fim Assistencia"].ToString()!),
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
            Equipamentos = row["Equipamentos"].ToString()!,
            Justificacao = row["Justificacao Incumprimento"].ToString()!
        };

        return result;
    }

    private static DateTime? ConvertDateTimeFromStrings(string datetime)
    {
        if (datetime == null)
            return null;

        try
        {
            return DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm:ss",
                                    new CultureInfo("pt-PT"),
                                    DateTimeStyles.None);
        }
        catch (Exception)
        {
            return null;
        }



    }
}
