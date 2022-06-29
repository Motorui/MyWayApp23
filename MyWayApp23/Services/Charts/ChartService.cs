using PSC.Blazor.Components.Chartjs.Enums;
using PSC.Blazor.Components.Chartjs.Models.Common;
using PSC.Blazor.Components.Chartjs.Models.Line;

namespace MyWayApp23.Services.Charts;

public class ChartService : IChartService
{
    public LineChartConfig GetPaxDemandData(List<HistoricoAssistencia> historico)
    {
        List<PaxDemandModel> PaxDemand = historico.AsEnumerable()
            .GroupBy(d => new { Dia = d.Data.Date })
            .Select(x => new PaxDemandModel
            {
                Dias = x.Key.Dia,
                Total = x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date)),
                Partidas = x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date) && d.Mov == "D"),
                Chegadas = x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date) && d.Mov == "A"),
            }).OrderBy(d => d.Dias).ToList();

        LineChartConfig _paxDemandConfig = new();

        _paxDemandConfig.Data.Labels = PaxDemand.Select(d => d.Dias.ToString("d/MMM")).ToList();

        _paxDemandConfig = new LineChartConfig()
        {
            Options = new Options()
            {
                Responsive = true,
                MaintainAspectRatio = false,
                Plugins = new Plugins()
                {
                    Legend = new Legend()
                    {
                        Align = LegendAlign.Center,
                        Display = true,
                        Position = LegendPosition.Bottom
                    }
                },
            }
        };

        _paxDemandConfig.Data.Labels = PaxDemand.Select(d => d.Dias.ToString("d/MMM")).ToList();
        _paxDemandConfig.Data.Datasets.Add(new LineDataset()
        {
            Label = "Real",
            Data = PaxDemand.Select(d => d.Total).ToList(),
            BackgroundColor = "rgba(220,20,60,0.2)",
            BorderColor = "rgba(220,20,60,1)",
            Fill = true
        });
        _paxDemandConfig.Data.Datasets.Add(new LineDataset()
        {
            Label = "Dep.",
            Data = PaxDemand.Select(d => d.Partidas).ToList(),
            BackgroundColor = "rgba(34,139,34,0.2)",
            BorderColor = "rgba(34,139,34,1)",
            Fill = true
        });
        _paxDemandConfig.Data.Datasets.Add(new LineDataset()
        {
            Label = "Arr.",
            Data = PaxDemand.Select(d => d.Chegadas).ToList(),
            BackgroundColor = "rgba(30,144,255,0.2)",
            BorderColor = "rgba(30,144,255,1)",
            Fill = true
        });

        return _paxDemandConfig;
    }

    public LineChartConfig GetDemandByShiftData(List<HistoricoAssistencia> historico)
    {
        List<DemandByShiftModel> demandsByShift = historico.AsEnumerable()
            .GroupBy(d => new { Dia = d.Data.Date })
            .Select(x => new DemandByShiftModel
            {
                Dias = x.Key.Dia,
                Manha = x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date) &&
                    d.Data.Hour >= 4 && d.Data.Hour < 13),
                Tarde = x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date) &&
                    d.Data.Hour >= 13 && d.Data.Hour < 23),
                Noite = x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date) &&
                    d.Data.Hour >= 0 && d.Data.Hour < 4),
            }).OrderBy(d => d.Dias).ToList();

        LineChartConfig _demandsByShiftChartConfig = new();

        _demandsByShiftChartConfig = new LineChartConfig()
        {
            Options = new Options()
            {
                Responsive = true,
                MaintainAspectRatio = false,
                Plugins = new Plugins()
                {
                    Legend = new Legend()
                    {
                        Align = LegendAlign.Center,
                        Display = true,
                        Position = LegendPosition.Bottom
                    }
                },
            }
        };

        _demandsByShiftChartConfig.Data.Labels = demandsByShift.Select(d => d.Dias.ToString("d/MMM")).ToList();
        _demandsByShiftChartConfig.Data.Datasets.Add(new LineDataset()
        {
            Label = "Manhã",
            Data = demandsByShift.Select(d => d.Manha).ToList(),
            BackgroundColor = "rgba(220,20,60,0.2)",
            BorderColor = "rgba(220,20,60,1)",
            Fill = true
        });
        _demandsByShiftChartConfig.Data.Datasets.Add(new LineDataset()
        {
            Label = "Tarde",
            Data = demandsByShift.Select(d => d.Tarde).ToList(),
            BackgroundColor = "rgba(34,139,34,0.2)",
            BorderColor = "rgba(34,139,34,1)",
            Fill = true
        });
        _demandsByShiftChartConfig.Data.Datasets.Add(new LineDataset()
        {
            Label = "Noite",
            Data = demandsByShift.Select(d => d.Noite).ToList(),
            BackgroundColor = "rgba(30,144,255,0.2)",
            BorderColor = "rgba(30,144,255,1)",
            Fill = true
        });

        return _demandsByShiftChartConfig;
    }
}
