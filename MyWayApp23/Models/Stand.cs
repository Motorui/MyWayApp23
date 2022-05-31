namespace MyWayApp23.Models
{
    [Table("Stands")]
    public class Stand : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "UH:")]
        public string Aeroporto { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Stand:")]
        public string Numero { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Tipo:")]
        public string Tipo { get; set; } = string.Empty;

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

}
