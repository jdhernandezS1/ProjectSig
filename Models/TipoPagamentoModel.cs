using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class TipoPagamentoModel
    {
        [Key]
<<<<<<< HEAD
        public int IdTipoPagamento{ get; set; }
        [Required]
=======
>>>>>>> fae79dd8d590fb61295b7371cc064b6c93044b72
        [MaxLength(30)]
        public required string Pagamento { get; set; }
    }
}
