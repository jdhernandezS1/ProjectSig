using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models;

public partial class Tipomobilio
{
    [Key]
    public int id { get; set; }
    [Required]
    public string Tipomobilio1 { get; set; } = null!;

    public virtual ICollection<Mobilio> Mobilios { get; set; } = new List<Mobilio>();
}
