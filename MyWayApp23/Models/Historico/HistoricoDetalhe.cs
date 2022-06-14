namespace MyWayApp23.Models.Historico;

[Table("HistoricoDetalhe")]
public class HistoricoDetalhe : IBaseEntity
{
    private string diaSemana = string.Empty;

    [Key]
    public Guid Id { get; set; }
    public string Uh { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string DiaSemana
    {
        get => diaSemana;
        set => diaSemana = Data.DayOfWeek.ToString()[..3];
    }
    public int TotalDia { get; set; }
    public int Dep { get; set; }
    public string DepPercentage { get; set; } = string.Empty;
    public int Arr { get; set; }
    public string ArrPercentage { get; set; } = string.Empty;
    public int JetBridge { get; set; }
    public string JetBridgePercentage { get; set; } = string.Empty;
    public int Remote { get; set; }
    public string RemotePercentage { get; set; } = string.Empty;
    public double Mais36 { get; set; }
    public string PercentageMais36 { get; set; } = string.Empty;
    public double Menos36 { get; set; }
    public string PercentageMenos36 { get; set; } = string.Empty;
    public int Wchr { get; set; }
    public int Wchs { get; set; }
    public int Wchc { get; set; }
    public int Maas { get; set; }
    public int Blnd { get; set; }
    public int Deaf { get; set; }
    public int Dpna { get; set; }
    public int Stcr { get; set; }
    public int Meda { get; set; }
    public int Wcmp { get; set; }
    public int Wcbd { get; set; }
    public int Wcbw { get; set; }
    public double Media { get; set; }
    #region BaseEntity

    [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
    public DateTime? CreatedAt { get; set; }

    [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
    public string CreatedBy { get; set; } = string.Empty;

    [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
    public DateTime? LastUpdatedAt { get; set; }

    [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
    public string LastUpdatedBy { get; set; } = string.Empty;

    #endregion
}

