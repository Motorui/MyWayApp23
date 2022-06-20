using System.Text.RegularExpressions;

namespace MyWayApp23.Helpers;

public static class StringHelper
{
    public static string ConvertToId(string uh, DateTime data, string inicio,
        string voo, string mov, string pax)
    {
        Regex rgx = new("[^a-zA-Z0-9-]");
        string id = rgx.Replace(uh, "")
            + "-" + data.ToString()
            + "-" + rgx.Replace(inicio, "")
            + "-" + rgx.Replace(voo, "")
            + "-" + rgx.Replace(mov, "")
            + "-" + rgx.Replace(pax, "");
        return id.ToUpper();
    }

    public static string ConvertToHistoricoId(HistoricoAssistencia row)
    {
        string inicio = row.Inicio.HasValue ? row.Inicio.Value.Ticks.ToString() : row.Data.Ticks.ToString();
        string id = row.Aeroporto.RemoveNonAlphanumeric().Trim()
            + "-" + row.Data.Ticks.ToString().RemoveWhitespace().Trim()
            + "-" + inicio.RemoveWhitespace().Trim()
            + "-" + row.Voo.RemoveNonAlphanumeric().Trim()
            + "-" + row.Mov.RemoveNonAlphanumeric().Trim()
            + "-" + row.Pax.RemoveNonAlphanumeric().Trim()
            + "-" + row.SSR.RemoveNonAlphanumeric().Trim();
        return id.RemoveWhitespace().ToUpper();
    }
}
