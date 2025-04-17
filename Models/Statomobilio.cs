using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models;

public partial class Statomobilio
{
    [Key]
    public int id { get; set; }
    [Required]
    public string Statomobilio1 { get; set; } = null!;

    public virtual ICollection<Mobilio> Mobilios { get; set; } = new List<Mobilio>();
}
