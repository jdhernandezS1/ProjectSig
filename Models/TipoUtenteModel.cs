using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class TipoUtenteModel
    {
        [Key]
        public int IdTipoUtente{ get; set; }
        [Required]
        public required string TipoUtente { get; set; }
    }
}
