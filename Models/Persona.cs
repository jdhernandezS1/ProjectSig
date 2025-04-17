using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace armadieti2.Models;

public partial class Persona
{
    [Key]
    public int Idpersona { get; set; }
    [Required]
    public string Nome { get; set; } = null!;
    [Required]
    public string Cognome { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Idmonitor { get; set; } = null!;
    [Required]
    public int Tipopersona { get; set; }
    [Required]
    public int Dipartimento { get; set; } 

    public virtual ICollection<Noleggio> Noleggios { get; set; } = new List<Noleggio>();
    [ForeignKey("Dipartimento")]

    public virtual Dipartimento? NomedipartimentoNavigation { get; set; } 

    [ForeignKey("Tipopersona")]
    public Tipopersona? Tipopersonas { get; set; } 
}
