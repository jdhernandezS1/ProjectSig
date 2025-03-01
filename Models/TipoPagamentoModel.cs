using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class TipoPagamentoModel
    {
        [Key]
        [MaxLength(30)]
        public required string Pagamento { get; set; }
    }
}
