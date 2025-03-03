using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class DipartimentoModel
    {
        [Key]
<<<<<<< HEAD
        public int IdDipartimento{ get; set; }
        [Required]
=======
>>>>>>> fae79dd8d590fb61295b7371cc064b6c93044b72
        [MaxLength(50)]
        public required string NomeDipartimento { get; set; }
    }
}
