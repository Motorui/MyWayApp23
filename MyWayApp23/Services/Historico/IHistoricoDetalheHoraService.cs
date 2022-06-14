namespace MyWayApp23.Services.Historico;

public interface IHistoricoDetalheHoraService
{
    List<HistoricoDetalheHora> GetDetalhesHora(DateTime data);
}