using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace armadieti2.Models;

public partial class Noleggio
{
    [Key]
    public int Idnoleggio { get; set; }
    [Required]
    public DateTime Datainizio { get; set; }
    [Required]
    public DateTime Datafine { get; set; }
    [Required]
    public int Idmobilio { get; set; }
    [Required]
    public int Idpersona { get; set; }

    [Required]
    [Display(Name = "Stato")]
    public StatoNoleggioEnum StatoAttivo { get; set; } = StatoNoleggioEnum.Attivo; 

    [ForeignKey("Idmobilio")]
    public virtual Mobilio? IdmobilioNavigation { get; set; }

    [ForeignKey("Idpersona")]
    public virtual Persona? IdpersonaNavigation { get; set; } 

    public virtual ICollection<Movimento> Movimentos { get; set; } = new List<Movimento>();
}
