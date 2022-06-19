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
        Regex rgx = new("[^a-zA-Z0-9 -]");
        string inicio = row.Inicio.HasValue ? row.Inicio.Value.Ticks.ToString() : row.Data.Ticks.ToString();
        string id = rgx.Replace(row.Aeroporto.Trim(), "")
            + "-" + row.Data.Ticks.ToString()
            + "-" + inicio
            + "-" + rgx.Replace(row.Voo.Trim(), "")
            + "-" + rgx.Replace(row.Mov.Trim(), "")
            + "-" + rgx.Replace(row.Pax.Trim(), "")
            + "-" + rgx.Replace(row.SSR.Trim(), "");
        return id.ToUpper();
    }
}
