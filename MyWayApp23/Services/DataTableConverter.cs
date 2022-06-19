using MyWayApp23.Extensions;
using System.Reflection;

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
            //Id = Guid.NewGuid(),
            Msg = row["Tipo Msg"].ToString()!,
            Aeroporto = row["Aeroporto"].ToString()!,
            Notif = row["Notif"].ToString().ConvertToLong(),
            Data = DateTime.ParseExact(row["Data Voo"].ToString()! + " " + row["Hora Voo"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
            Contacto = DateHelper.ConvertDateTimeFromStrings(row["Data Contacto"].ToString()! + " " + row["Hora Contacto"].ToString()!),
            Calcos = DateHelper.ConvertDateTimeFromStrings(row["Data Calcos"].ToString()! + " " + row["Hora Calcos"].ToString()!),
            Inicio = DateHelper.ConvertDateTimeFromStrings(row["Data Inicio Assistencia"].ToString()! + " " + row["Hora Inicio Assistencia"].ToString()!),
            Fim = DateHelper.ConvertDateTimeFromStrings(row["Data Fim Assistencia"].ToString()! + " " + row["Hora Fim Assistencia"].ToString()!),
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

    public List<HistoricoAssistencia> ConvertDtToHistorico(DataTable dt)
    {
        var historicoList = new List<HistoricoAssistencia>(dt.Rows.Count);
        foreach (DataRow row in dt.Rows)
        {
            var values = row.ItemArray;
            var historico = new HistoricoAssistencia()
            {
                Msg = values[0]!.ToString()!,
                Aeroporto = values[1]!.ToString()!,
                Notif = values[2]!.ToString().ConvertToLong(),
                Data = DateTime.ParseExact(values[3]!.ToString()! + " " + values[4]!.ToString()!, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Contacto = DateHelper.ConvertDateTimeFromStrings(values[5]!.ToString()! + " " + values[6]!.ToString()!),
                Calcos = DateHelper.ConvertDateTimeFromStrings(values[7]!.ToString()! + " " + values[8]!.ToString()!),
                Inicio = DateHelper.ConvertDateTimeFromStrings(values[9]!.ToString()! + " " + values[10]!.ToString()!),
                Fim = DateHelper.ConvertDateTimeFromStrings(values[11]!.ToString()! + " " + values[12]!.ToString()!),
                //Duracao = StringHelper.AverageFromStrings(values[12]!.ToString(), values[10]!.ToString()),
                Voo = values[13]!.ToString()!,
                Mov = values[14]!.ToString()!,
                OrigDest = values[15]!.ToString()!,
                Pax = values[16]!.ToString()!,
                SSR = values[17]!.ToString()!,
                AC = values[18]!.ToString()!,
                Stand = values[19]!.ToString()!,
                Exit = values[20]!.ToString()!,
                CkIn = values[21]!.ToString()!,
                Gate = values[22]!.ToString()!,
                Transferencia = values[23]!.ToString()!,
                Equipamentos = values[24]!.ToString()!,
                Justificacao = values[25]!.ToString()!
            };
;
            historico.Duracao = DateHelper.SubtractFromDates(historico.Fim, historico.Inicio);
            historico.Id = StringHelper.ConvertToHistoricoId(historico);

            historicoList.Add(historico);
        }

        return historicoList;
    }

}
