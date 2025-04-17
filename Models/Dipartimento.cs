using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models;

public partial class Dipartimento
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nomedipartimento { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
