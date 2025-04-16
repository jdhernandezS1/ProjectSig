using System;
using System.Collections.Generic;

namespace armadieti2.Models;

public partial class Tipomobilio
{
    public string Tipomobilio1 { get; set; } = null!;

    public virtual ICollection<Mobilio> Mobilios { get; set; } = new List<Mobilio>();
}
