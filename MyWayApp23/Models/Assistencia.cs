namespace MyWayApp23.Models;

[Table("Assistencias")]
public class Assistencia : IBaseEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [Display(Name = "UH:")]
    public string Aeroporto { get; set; } = string.Empty;

    [Display(Name = "Mensagem:")]
    public string Msg { get; set; } = string.Empty;

    [Display(Name = "Notificação:")]
    public string Notif { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Data:")]
    public DateTime Data { get; set; }

    [Required]
    [Display(Name = "Voo:")]
    public string Voo { get; set; } = string.Empty;

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

    [Display(Name = "Hora de embarque estimada:")]
    public DateTime? HoraEmbarque { get; set; } = null;

    [Display(Name = "Saída da Staging Area:")]
    public DateTime? SaidaStaging { get; set; } = null;

    [Display(Name = "Estimativa de apresentação:")]
    public DateTime? EstimaApresentacao { get; set; } = null;

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
