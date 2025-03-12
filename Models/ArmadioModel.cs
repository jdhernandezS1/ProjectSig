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
        public required int IdStatoArmadio { get; set; }
        [ForeignKey("IdStatoArmadio")]

        public StatoArmadioModel? StatoArmadioModel { get; set; }
        public required int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]

        public CategoriaArmadioModel? CategoriaArmadioModel { get; set; }
    }

    
    
}