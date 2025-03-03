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
<<<<<<< HEAD
        public required int IdTipoUtente { get; set; }
        [ForeignKey("IdTipoUtente")]
        public required TipoUtenteModel TipoUtenteModel { get; set; }

        public required int IdDipartimento { get; set; }
        [ForeignKey("IdDipartimento")]
=======
        public required string TipoUtente { get; set; }
        [ForeignKey("TipoUtente")]
        public required TipoUtenteModel TipoUtenteModel { get; set; }

        public required string NomeDipartimento { get; set; }
        [ForeignKey("NomeDipartimento")]
>>>>>>> fae79dd8d590fb61295b7371cc064b6c93044b72
        public required DipartimentoModel DipartimentoModel { get; set; }
    }

}
