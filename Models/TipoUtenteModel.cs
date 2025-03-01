using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class TipoUtenteModel
    {
        [Key]
        public required string TipoUtente { get; set; }
    }
}
