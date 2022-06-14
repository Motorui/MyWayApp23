namespace MyWayApp23.Models.Historico;

public class HistoricoAverageTime
{
    [Key]
    public Guid Id { get; set; }
    public string Uh { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Mes { get; set; } = string.Empty;
    public double Seg { get; set; }
    public double Ter { get; set; }
    public double Qua { get; set; }
    public double Qui { get; set; }
    public double Sex { get; set; }
    public double Sab { get; set; }
    public double Dom { get; set; }
}
