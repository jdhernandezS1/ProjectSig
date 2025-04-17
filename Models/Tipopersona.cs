using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models;

public partial class Tipopersona
{
    [Key]
    public int IdTiPersona { get; set; } 
    [Required]
    public string Tipopersona1 { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
