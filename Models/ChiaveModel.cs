using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{


    public class ChiaveModel
    {
        [Key]
        public int IdChiave { get; set; }

        public required int IdArmadio { get; set; }
        [ForeignKey("IdArmadio")]
        public ArmadioModel? ArmadioModel { get; set; }

        public required int IdStatoChiave { get; set; }
        [ForeignKey("IdStatoChiave")]
        public StatoChiaveModel? StatoChiaveModel { get; set; }

        [Required]
        public DateTime DataModifica { get; private set; } = DateTime.UtcNow;

        public void AggiornaDataModifica()
        {
            DataModifica = DateTime.UtcNow;
        }
    }
}
