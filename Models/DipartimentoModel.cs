using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class DipartimentoModel
    {
        [Key]
        [MaxLength(50)]
        public required string NomeDipartimento { get; set; }
    }
}
