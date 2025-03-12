using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class CategoriaArmadioModel
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required]
        public required string CategoriaArmadio { get; set; }
    }
}
