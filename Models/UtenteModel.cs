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
        public required int IdTipoUtente { get; set; }
        [ForeignKey("IdTipoUtente")]
        public required TipoUtenteModel TipoUtenteModel { get; set; }

        public required int IdDipartimento { get; set; }
        [ForeignKey("IdDipartimento")]
        public required DipartimentoModel DipartimentoModel { get; set; }
    }

}
