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
        public required string StatoArmadio { get; set; }
        [ForeignKey("StatoArmadio")]

        public required StatoArmadioModel StatoArmadioModel { get; set; }
        public required string CategoriaArmadio { get; set; }
        [ForeignKey("CategoriaArmadio")]

        public required CategoriaArmadioModel CategoriaArmadioModel { get; set; }
    }

    
    
}