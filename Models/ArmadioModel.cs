using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace armadieti2.Models
{


    public class ArmadioModel
    {
        [Key]
        public int IdArmadio { get; set; }

        [Required]
        public required string Piano { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
<<<<<<< HEAD
        public required int IdStatoArmadio { get; set; }
        [ForeignKey("IdStatoArmadio")]

        public required StatoArmadioModel StatoArmadioModel { get; set; }
        public required int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
=======
        public required string StatoArmadio { get; set; }
        [ForeignKey("StatoArmadio")]

        public required StatoArmadioModel StatoArmadioModel { get; set; }
        public required string CategoriaArmadio { get; set; }
        [ForeignKey("CategoriaArmadio")]
>>>>>>> fae79dd8d590fb61295b7371cc064b6c93044b72

        public required CategoriaArmadioModel CategoriaArmadioModel { get; set; }
    }

    
    
}