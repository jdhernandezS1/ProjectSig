using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class CategoriaArmadioModel
    {
        [Key]
        public required string CategoriaArmadio { get; set; }
    }
}
