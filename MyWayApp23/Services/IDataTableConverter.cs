namespace MyWayApp23.Services
{
    public interface IDataTableConverter
    {
        List<Assistencia> ConvertDataTableToAssistencias(DataTable tbl);
        List<HistoricoAssistencia> ConvertDataTableToHistorico(DataTable tbl);
        Assistencia ConvertRowToAssistencia(DataRow row);
        HistoricoAssistencia ConvertRowToHistorico(DataRow row);
        string ReturnFileType(DataTable tbl);
    }
}