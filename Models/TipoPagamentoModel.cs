using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class TipoPagamentoModel
    {
        [Key]
        public int IdTipoPagamento{ get; set; }
        [Required]
        [MaxLength(30)]
        public required string Pagamento { get; set; }
    }
}
