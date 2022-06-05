namespace MyWayApp23.Services
{
    public interface IHistoricoDetalheHoraService
    {
        List<HistoricoDetalheHora> GetDetalhesHora(DateTime data);
    }
}