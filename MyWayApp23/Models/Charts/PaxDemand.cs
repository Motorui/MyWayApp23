namespace MyWayApp23.Models.Charts;

public class PaxDemand
{
    public List<string> Dias { get; set; } = new();
    public List<decimal> Total { get; set; } = new();
    public List<decimal> Partidas { get; set; } = new();
    public List<decimal> Chegadas { get; set; } = new();
}
