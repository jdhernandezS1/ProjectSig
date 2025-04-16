using System;
using System.Collections.Generic;

namespace armadieti2.Models;

public partial class Noleggio
{
    public int Idnoleggio { get; set; }

    public DateOnly Datainizio { get; set; }

    public DateOnly Datafine { get; set; }

    public int Idmobilio { get; set; }

    public int Idpersona { get; set; }

    public bool? Attivo { get; set; }

    public virtual Mobilio IdmobilioNavigation { get; set; } = null!;

    public virtual Persona IdpersonaNavigation { get; set; } = null!;

    public virtual ICollection<Movimento> Movimentos { get; set; } = new List<Movimento>();
}
