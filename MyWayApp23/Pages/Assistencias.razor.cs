using Microsoft.AspNetCore.Components;

namespace MyWayApp23.Pages;
public partial class Assistencias
{
    [Inject]
    protected IHistoricoDetalheService DetalheService { get; set; } = default!;
    [Inject]
    protected IHistoricoDetalheHoraService DetalheHorasService { get; set; } = default!;

    bool isVisible = true;
    DateTime? _date = DateTime.Today;
    private IEnumerable<HistoricoDetalhe> detalhes = new List<HistoricoDetalhe>();
    private IEnumerable<HistoricoDetalheHora> detalhesHora = new List<HistoricoDetalheHora>();
    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(5);
        detalhes = DetalheService.GetDetalhes(DateTime.UtcNow).OrderByDescending(d => d.Data);
        detalhesHora = DetalheHorasService.GetDetalhesHora(DateTime.UtcNow).OrderByDescending(d => d.Data);
        isVisible = false;
    }

    private void OnDateChange(DateTime? newDate)
    {
        isVisible = true;
        _date = newDate;
        if (newDate != null)
        {
            detalhes = DetalheService.GetDetalhes((DateTime)newDate).OrderByDescending(d => d.Data);
            detalhesHora = DetalheHorasService.GetDetalhesHora((DateTime)newDate).OrderByDescending(d => d.Data);
        }
        isVisible = false;
    }
}