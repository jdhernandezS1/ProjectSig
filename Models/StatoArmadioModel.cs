using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class StatoArmadioModel
    {
        [Key]
        public int IdStatoArmadio { get; set; }
        [Required]
        public required string StatoArmadio { get; set; }
    }
}
