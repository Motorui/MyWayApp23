namespace MyWayApp23.Models.Charts;

public class DemandByWeekdayModel
{
    public DayOfWeek DayOfWeek { get; set; }
    public string DiaSemana { get; set; } = string.Empty;
    public decimal Jan { get; set; }
    public decimal Fev { get; set; }
    public decimal Mar { get; set; }
    public decimal Abr { get; set; }
    public decimal Mai { get; set; }
    public decimal Jun { get; set; }
    public decimal Jul { get; set; }
    public decimal Ago { get; set; }
    public decimal Set { get; set; }
    public decimal Out { get; set; }
    public decimal Nov { get; set; }
    public decimal Dez { get; set; }
}
