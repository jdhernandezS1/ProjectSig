using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class CategoriaArmadioModel
    {
        [Key]
<<<<<<< HEAD
        public int IdCategoria { get; set; }
        [Required]
=======
>>>>>>> fae79dd8d590fb61295b7371cc064b6c93044b72
        public required string CategoriaArmadio { get; set; }
    }
}
