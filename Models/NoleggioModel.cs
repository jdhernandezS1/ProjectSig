using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{

    public class NoleggioModel
    {
        [Key]
        public int IdNoleggio { get; set; }

        private DateTime _dataInizio;
        private DateTime _dataFine;

        public DateTime DataInizio
        {
            get => _dataInizio;
            set => _dataInizio = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        [Required]
        public DateTime DataFine
        {
            get => _dataFine;
            set => _dataFine = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        public  int IdTipoPagamento { get; set; }

        [ForeignKey("IdTipoPagamento")]
        public TipoPagamentoModel? TipoPagamentoModel { get; set; }

        public required double Cauzione { get; set; }

        public required int IdArmadio { get; set; }
        [ForeignKey("IdArmadio")]
        public  ArmadioModel? ArmadioModel { get; set; }

        public required int IdChiave { get; set; }
        [ForeignKey("IdChiave")]
        public ChiaveModel? ChiaveModel { get; set; }

        public required int IdUtente { get; set; }
        [ForeignKey("IdUtente")]
        public UtenteModel? UtenteModel { get; set; }

    }
}
