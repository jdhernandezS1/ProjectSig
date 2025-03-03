using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{

    public class NoleggioModel
    {
        [Key]
        public int IdNoleggio { get; set; }

        [Required]
        public DateTime DataInizio { get; private set; } = DateTime.UtcNow;

        [Required]
        public DateTime DataFine { get; set; }

        [Required]
        [MaxLength(30)]
<<<<<<< HEAD
        public required int IdTipoPagamento { get; set; }

        [ForeignKey("IdTipoPagamento")]
=======
        public required string Pagamento { get; set; }

        [ForeignKey("Pagamento")]
>>>>>>> fae79dd8d590fb61295b7371cc064b6c93044b72
        public required TipoPagamentoModel TipoPagamentoModel { get; set; }

        [Required]
        public decimal Cauzione { get; set; }

        public int IdArmadio { get; set; }
        [ForeignKey("IdArmadio")]
        public required ArmadioModel ArmadioModel { get; set; }

        public int IdChiave { get; set; }
        [ForeignKey("IdChiave")]
        public required ChiaveModel ChiaveModel { get; set; }

        public int IdUtente { get; set; }
        [ForeignKey("IdUtente")]
        public required UtenteModel UtenteModel { get; set; }

        public void AggiornaDataInizio()
        {
            DataInizio = DateTime.UtcNow;
        }
    }
}
