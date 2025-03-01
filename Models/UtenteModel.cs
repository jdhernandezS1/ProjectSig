using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class UtenteModel
    {
        [Key]
        public int IdUtente { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Cognome { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string? IdMonitor { get; set; }

        [Required]
        public required string TipoUtente { get; set; }
        [ForeignKey("TipoUtente")]
        public required TipoUtenteModel TipoUtenteModel { get; set; }

        public required string NomeDipartimento { get; set; }
        [ForeignKey("NomeDipartimento")]
        public required DipartimentoModel DipartimentoModel { get; set; }
    }

}
