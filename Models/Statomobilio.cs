using System;
using System.Collections.Generic;

namespace armadieti2.Models;

public partial class Statomobilio
{
    public string Statomobilio1 { get; set; } = null!;

    public virtual ICollection<Mobilio> Mobilios { get; set; } = new List<Mobilio>();
}
