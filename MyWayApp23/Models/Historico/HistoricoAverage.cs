namespace MyWayApp23.Models.Historico;

public class HistoricoAverage 
{
    [Key]
    public Guid Id { get; set; }
    public string Uh { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Mes { get; set; } = string.Empty;
    public int Seg { get; set; }
    public int Ter { get; set; }
    public int Qua { get; set; }
    public int Qui { get; set; }
    public int Sex { get; set; }
    public int Sab { get; set; }
    public int Dom { get; set; }
}
