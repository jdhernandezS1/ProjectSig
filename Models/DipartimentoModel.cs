using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class DipartimentoModel
    {
        [Key]
        public int IdDipartimento{ get; set; }
        [Required]
        [MaxLength(50)]
        public required string NomeDipartimento { get; set; }
    }
}
