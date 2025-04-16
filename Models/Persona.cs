using System;
using System.Collections.Generic;

namespace armadieti2.Models;

public partial class Persona
{
    public int Idpersona { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Idmonitor { get; set; } = null!;

    public string Tipopersona { get; set; } = null!;

    public string Nomedipartimento { get; set; } = null!;

    public virtual ICollection<Noleggio> Noleggios { get; set; } = new List<Noleggio>();

    public virtual Dipartimento NomedipartimentoNavigation { get; set; } = null!;

    public virtual Tipopersona TipopersonaNavigation { get; set; } = null!;
}
