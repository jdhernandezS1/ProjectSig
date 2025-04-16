using System;
using System.Collections.Generic;

namespace armadieti2.Models;

public partial class Mobilio
{
    public int Idmobilio { get; set; }

    public int Numero { get; set; }

    public int Idlocation { get; set; }

    public string Tipomobilio { get; set; } = null!;

    public int Numerochiave { get; set; }

    public string Statomobilio { get; set; } = null!;

    public virtual Location IdlocationNavigation { get; set; } = null!;

    public virtual ICollection<Noleggio> Noleggios { get; set; } = new List<Noleggio>();

    public virtual Chiave NumerochiaveNavigation { get; set; } = null!;

    public virtual Statomobilio StatomobilioNavigation { get; set; } = null!;

    public virtual Tipomobilio TipomobilioNavigation { get; set; } = null!;
}
