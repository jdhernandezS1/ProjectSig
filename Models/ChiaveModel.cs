﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{


    public class ChiaveModel
    {
        [Key]
        public int IdChiave { get; set; }

        public required int IdArmadio { get; set; }
        [ForeignKey("IdArmadio")]
        public required ArmadioModel ArmadioModel { get; set; }

<<<<<<< HEAD
        public required int IdStatoChiave { get; set; }
        [ForeignKey("IdStatoChiave")]
=======
        public required string StatoChiave { get; set; }
        [ForeignKey("StatoChiave")]
>>>>>>> fae79dd8d590fb61295b7371cc064b6c93044b72
        public required StatoChiaveModel StatoChiaveModel { get; set; }

        [Required]
        public DateTime DataModifica { get; private set; } = DateTime.UtcNow;

        public void AggiornaDataModifica()
        {
            DataModifica = DateTime.UtcNow;
        }
    }
}
