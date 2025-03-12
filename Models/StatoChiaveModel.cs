using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class StatoChiaveModel
    {
        [Key]
        public int IdStatoChiave{ get; set; }
        [Required]
        public required string StatoChiave { get; set; } 
    }
}
