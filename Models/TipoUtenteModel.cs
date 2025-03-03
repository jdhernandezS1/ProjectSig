using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class TipoUtenteModel
    {
        [Key]
<<<<<<< HEAD
        public int IdTipoUtente{ get; set; }
        [Required]
=======
>>>>>>> fae79dd8d590fb61295b7371cc064b6c93044b72
        public required string TipoUtente { get; set; }
    }
}
