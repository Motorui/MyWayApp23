using PSC.Blazor.Components.Chartjs.Enums;
using PSC.Blazor.Components.Chartjs.Models.Common;
using PSC.Blazor.Components.Chartjs.Models.Line;

namespace MyWayApp23.Services.Charts;

public class ChartService : ChartServiceBase, IChartService
{
    private readonly IStandService standService;

    public ChartService(IStandService standService)
    {
        this.standService = standService;
    }

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
            Fill = true,

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

        Dictionary<string, List<decimal>> DemandByWeekDayData = FillDemandByWeekDay(DemandByWeekday);

        foreach (var item in DemandByWeekDayData)
        {
            string color = RandomRgbaColor(1);
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = item.Key,
                Data = item.Value,
                BackgroundColor = color,
                BorderColor = color
            });
        }

        return _demandByWeekdayConfig;
    }

    public LineChartConfig GetRemoteByWeekdayData(List<HistoricoAssistencia> historico)
    {
        var uh = historico.Select(u => u.Aeroporto).First();
        var stands = standService.GetStands(false, uh);

        List<DemandByWeekdayModel> DemandByWeekday = historico.AsEnumerable()
            .Where(r => stands.Contains(r.Stand!))
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

        Dictionary<string, List<decimal>> DemandByWeekDayData = FillDemandByWeekDay(DemandByWeekday);

        foreach (var item in DemandByWeekDayData)
        {
            string color = RandomRgbaColor(1);
            _demandByWeekdayConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = item.Key,
                Data = item.Value,
                BackgroundColor = color,
                BorderColor = color
            });
        }

        return _demandByWeekdayConfig;
    }

    public LineChartConfig GetPreNotificationData(List<HistoricoAssistencia> historico)
    {
        long notif = TimeSpan.FromHours(36).Ticks;
        List<PaxDemandModel> PaxDemand = historico.AsEnumerable()
            .GroupBy(d => new { Dia = d.Data.Date })
            .Select(x => new PaxDemandModel
            {
                Dias = x.Key.Dia,
                Total = x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date)),
                //notificadas
                Partidas = x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date) && d.Notif >= notif),
                //não notificadas
                Chegadas = x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date) && d.Notif < notif),
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
            Label = ">36h",
            Data = PaxDemand.Select(d => d.Partidas).ToList(),
            BackgroundColor = "rgba(34,139,34,0.2)",
            BorderColor = "rgba(34,139,34,1)",
            Fill = true
        });
        _paxDemandConfig.Data.Datasets.Add(new LineDataset()
        {
            Label = "<36h",
            Data = PaxDemand.Select(d => d.Chegadas).ToList(),
            BackgroundColor = "rgba(30,144,255,0.2)",
            BorderColor = "rgba(30,144,255,1)",
            Fill = true
        });

        return _paxDemandConfig;
    }

    public LineChartConfig GetNonNotifiedVsPaxDemandData(List<HistoricoAssistencia> historico)
    {
        long notif = TimeSpan.FromHours(36).Ticks;
        List<PaxDemandModel> PaxDemand = historico.AsEnumerable()
            .GroupBy(d => new { Dia = d.Data.Date })
            .Select(x => new PaxDemandModel
            {
                Dias = x.Key.Dia,
                Total = x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date)),
                //percentagens sem notificação
                Partidas = PercentageHelper.PercentageToDecimal(
                   x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date) && d.Notif < notif),
                     x.Count(d => d.Data.Date.Equals(x.Key.Dia.Date))
                    )
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
                    },
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
            Fill = true,

        });
        _paxDemandConfig.Data.Datasets.Add(new LineDataset()
        {
            Label = "%<36h",
            Data = PaxDemand.Select(d => d.Partidas).ToList(),
            BackgroundColor = "rgba(34,139,34,0.2)",
            BorderColor = "rgba(34,139,34,1)",
            Fill = true
        });

        return _paxDemandConfig;
    }
}