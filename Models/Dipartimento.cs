using System;
using System.Collections.Generic;

namespace armadieti2.Models;

public partial class Dipartimento
{
    public string Nomedipartimento { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
