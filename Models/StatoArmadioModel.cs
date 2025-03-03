using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class StatoArmadioModel
    {
        [Key]
<<<<<<< HEAD
        public int IdStatoArmadio { get; set; }
        [Required]
=======
>>>>>>> fae79dd8d590fb61295b7371cc064b6c93044b72
        public required string StatoArmadio { get; set; }
    }
}
