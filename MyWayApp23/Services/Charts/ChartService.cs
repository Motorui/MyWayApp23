using PSC.Blazor.Components.Chartjs.Enums;
using PSC.Blazor.Components.Chartjs.Models.Common;
using PSC.Blazor.Components.Chartjs.Models.Line;
using System.Linq;
using System.Linq.Expressions;

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
    public LineChartConfig GetDemandByWeekdayData(List<HistoricoAssistencia> historico)
    {
        List<DemandByWeekdayModel> DemandByWeekday = historico.AsEnumerable()
            .GroupBy(d => new { DiaSemana = d.Data.DayOfWeek })
            .Select(x => new DemandByWeekdayModel
            {
                DayOfWeek = x.Key.DiaSemana,
                DiaSemana = x.Select(d => d.Data.ToString("ddd", new CultureInfo("pt-PT"))).First(),
                Jan = x.Count(d => d.Data.Month.Equals(1)),
                Fev = x.Count(d => d.Data.Month.Equals(2)),
                Mar = x.Count(d => d.Data.Month.Equals(3)),
                Abr = x.Count(d => d.Data.Month.Equals(4)),
                Mai = x.Count(d => d.Data.Month.Equals(5)),
                Jun = x.Count(d => d.Data.Month.Equals(6)),
                Jul = x.Count(d => d.Data.Month.Equals(7)),
                Ago = x.Count(d => d.Data.Month.Equals(8)),
                Set = x.Count(d => d.Data.Month.Equals(9)),
                Out = x.Count(d => d.Data.Month.Equals(10)),
                Nov = x.Count(d => d.Data.Month.Equals(11)),
                Dez = x.Count(d => d.Data.Month.Equals(12)),
            }).OrderBy(d => (decimal)d.DayOfWeek).ToList();

        LineChartConfig _demandByWeekdayConfig = new();

        _demandByWeekdayConfig = new LineChartConfig()
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

        _demandByWeekdayConfig.Data.Labels = DemandByWeekday.Select(d => d.DiaSemana.ToString()).ToList();

        if (DemandByWeekday.Select(d => d.Jan).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Jan.",
                Data = DemandByWeekday.Select(d => d.Jan).ToList(),
                BackgroundColor = "rgba(138,10,244,0.2)",
                BorderColor = "rgba(138,10,244,1)",
                Fill = false
            });
        }

        if (DemandByWeekday.Select(d => d.Fev).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Fev.",
                Data = DemandByWeekday.Select(d => d.Fev).ToList(),
                BackgroundColor = "rgba(28,10,244,0.2)",
                BorderColor = "rgba(28,10,244,1)",
                Fill = false
            });
        }

        if (DemandByWeekday.Select(d => d.Mar).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Mar.",
                Data = DemandByWeekday.Select(d => d.Mar).ToList(),
                BackgroundColor = "rgba(10,148,244,0.2)",
                BorderColor = "rgba(10,148,244,1)",
                Fill = false
            });
        }


        if (DemandByWeekday.Select(d => d.Abr).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Abr.",
                Data = DemandByWeekday.Select(d => d.Abr).ToList(),
                BackgroundColor = "rgba(10,227,244,0.2)",
                BorderColor = "rgba(10,227,244,1)",
                Fill = false
            });
        }

        if (DemandByWeekday.Select(d => d.Mai).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Mai.",
                Data = DemandByWeekday.Select(d => d.Mai).ToList(),
                BackgroundColor = "rgba(10,244,177,0.2)",
                BorderColor = "rgba(10,244,177,1)",
                Fill = false
            });
        }

        if (DemandByWeekday.Select(d => d.Jun).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Jun.",
                Data = DemandByWeekday.Select(d => d.Jun).ToList(),
                BackgroundColor = "rgba(10,244,106,0.2)",
                BorderColor = "rgba(10,244,106,1)",
                Fill = false
            });
        }

        if (DemandByWeekday.Select(d => d.Jul).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Jul.",
                Data = DemandByWeekday.Select(d => d.Jul).ToList(),
                BackgroundColor = "rgba(24,244,10,0.2)",
                BorderColor = "rgba(24,244,10,1)",
                Fill = false
            });
        }

        if (DemandByWeekday.Select(d => d.Ago).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Ago.",
                Data = DemandByWeekday.Select(d => d.Ago).ToList(),
                BackgroundColor = "rgba(148,244,10,0.2)",
                BorderColor = "rgba(148,244,10,1)",
                Fill = false
            });
        }

        if (DemandByWeekday.Select(d => d.Set).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Set.",
                Data = DemandByWeekday.Select(d => d.Set).ToList(),
                BackgroundColor = "rgba(244,241,10,0.2)",
                BorderColor = "rgba(244,241,10,1)",
                Fill = false
            });
        }

        if (DemandByWeekday.Select(d => d.Out).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Out.",
                Data = DemandByWeekday.Select(d => d.Out).ToList(),
                BackgroundColor = "rgba(244,180,10,0.2)",
                BorderColor = "rgba(244,180,10,1)",
                Fill = false
            });

        }
        
        if (DemandByWeekday.Select(d => d.Nov).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Nov.",
                Data = DemandByWeekday.Select(d => d.Nov).ToList(),
                BackgroundColor = "rgba(244,92,10,0.2)",
                BorderColor = "rgba(244,92,10,1)",
                Fill = false
            });
        }

        if (DemandByWeekday.Select(d => d.Dez).ToList().Count > 0)
        {
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Dez.",
                Data = DemandByWeekday.Select(d => d.Dez).ToList(),
                BackgroundColor = "rgba(244,10,10,0.2)",
                BorderColor = "rgba(244,10,10,1)",
                Fill = false
            });
        }
        
        return _demandByWeekdayConfig;
    }
}
