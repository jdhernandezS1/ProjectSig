using System;
using System.Collections.Generic;

namespace armadieti2.Models;

public partial class Location
{
    public int Idlocation { get; set; }

    public string Stabile { get; set; } = null!;

    public string Piano { get; set; } = null!;

    public virtual ICollection<Mobilio> Mobilios { get; set; } = new List<Mobilio>();
}
