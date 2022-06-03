namespace MyWayApp23.Models;

[Table("HistoricoAssistencias")]
public class HistoricoAssistencia : IBaseEntity
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "Mensagem:")]
    public string Msg { get; set; } = string.Empty;

    [Required]
    [Display(Name = "UH:")]
    public string Aeroporto { get; set; } = string.Empty;

    [Display(Name = "Notificação:")]
    public double Notif { get; set; }

    [Required]
    [Display(Name = "Data:")]  // Data Voo + Hora Voo
    public DateTime Data { get; set; }

    [Display(Name = "Contacto:")]  // Data Contacto + Hora Contacto
    public DateTime? Contacto { get; set; } = null;

    [Display(Name = "Calcos:")]  // Data Calcos + Hora Calcos
    public DateTime? Calcos { get; set; } = null;

    [Display(Name = "Inicio:")]  // Data Inicio Assistencia + Hora Inicio Assistencia
    public DateTime? Inicio { get; set; } = null;

    [Display(Name = "Fim:")]  // Data Fim Assistencia + Hora Fim Assistencia
    public DateTime? Fim { get; set; } = null;

    [Required]
    [Display(Name = "Voo:")]
    public string Voo { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Movimento:")]
    public string Mov { get; set; } = string.Empty;

    [Display(Name = "Origem/Destino:")]
    public string? OrigDest { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Passageiro:")]
    public string Pax { get; set; } = string.Empty;

    [Display(Name = "SSR:")]
    public string SSR { get; set; } = string.Empty;

    [Display(Name = "Aeronave:")]
    public string? AC { get; set; } = string.Empty;

    [Display(Name = "Stand:")]
    public string? Stand { get; set; } = string.Empty;

    [Display(Name = "Saída:")]
    public string? Exit { get; set; } = string.Empty;

    [Display(Name = "Check-in:")]
    public string? CkIn { get; set; } = string.Empty;

    [Display(Name = "Porta:")]
    public string? Gate { get; set; } = string.Empty;

    [Display(Name = "Transferênçia:")]
    public string? Transferencia { get; set; } = string.Empty;

    [Display(Name = "Equipamentos:")]
    public string? Equipamentos { get; set; } = string.Empty;

    [Display(Name = "Justificação:")]
    public string? Justificacao { get; set; } = string.Empty;
    
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