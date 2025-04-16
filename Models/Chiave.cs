using System;
using System.Collections.Generic;

namespace armadieti2.Models;

public partial class Chiave
{
    public int Numerochiave { get; set; }

    public virtual ICollection<Mobilio> Mobilios { get; set; } = new List<Mobilio>();
}
