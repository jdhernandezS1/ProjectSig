using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models;

public partial class Location
{
    [Key]

    public int Idlocation { get; set; }
    [Required]
    public string Stabile { get; set; } = null!;
    [Required]
    public string Piano { get; set; } = null!;

    public virtual ICollection<Mobilio> Mobilios { get; set; } = new List<Mobilio>();
}
