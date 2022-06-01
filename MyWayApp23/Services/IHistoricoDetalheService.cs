namespace MyWayApp23.Services
{
    public interface IHistoricoDetalheService
    {
        List<HistoricoDetalhe> GetDetalhes(DateTime data);
    }
}