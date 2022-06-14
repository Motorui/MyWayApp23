namespace MyWayApp23.Services.Historico;

public interface IHistoricoDetalheService
{
    List<HistoricoDetalhe> GetDetalhes(DateTime data);
    List<HistoricoDetalhe> GetDetalhesAno(DateTime data);
}
