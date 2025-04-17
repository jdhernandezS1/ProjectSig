using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models;

public partial class Chiave
{
    [Key]
    public int id { get; set; }
    [Required]
    public int Numerochiave { get; set; }

    public virtual ICollection<Mobilio> Mobilios { get; set; } = new List<Mobilio>();
}
