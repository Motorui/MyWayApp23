namespace MyWayApp23.Models.Historico;

[Table("HistoricoDetalheHora")]
public class HistoricoDetalheHora : IBaseEntity
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
    public int Zero { get; set; }
    public int Uma { get; set; }
    public int Duas { get; set; }
    public int Tres { get; set; }
    public int Quatro { get; set; }
    public int Cinco { get; set; }
    public int Seis { get; set; }
    public int Sete { get; set; }
    public int Oito { get; set; }
    public int Nove { get; set; }
    public int Dez { get; set; }
    public int Onze { get; set; }
    public int Doze { get; set; }
    public int Treze { get; set; }
    public int Quatorze { get; set; }
    public int Quinze { get; set; }
    public int Dezaseis { get; set; }
    public int Dezasete { get; set; }
    public int Dezoito { get; set; }
    public int Dezanove { get; set; }
    public int Vinte { get; set; }
    public int Vinteeum { get; set; }
    public int Vinteedois { get; set; }
    public int Vinteetres { get; set; }
    public int Manha { get; set; }
    public int Tarde { get; set; }
    public int Noite { get; set; }
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
