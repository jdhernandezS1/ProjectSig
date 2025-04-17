using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace armadieti2.Models;

public partial class Mobilio
{
    [Key]
    public int Idmobilio { get; set; }
    [Required]
    public int Numero { get; set; }
    [Required]
    public int Idlocation { get; set; }
    [Required]
    public int Tipomobilio { get; set; } 
    [Required]
    public int Numerochiave { get; set; }
    [Required]
    public int Statomobilio { get; set; }
    [ForeignKey("Idlocation")]
    public virtual Location? IdlocationNavigation { get; set; }

    public virtual ICollection<Noleggio> Noleggios { get; set; } = new List<Noleggio>();
    [ForeignKey("Numerochiave")]
    public virtual Chiave? NumerochiaveNavigation { get; set; }
    [ForeignKey("Statomobilio")]
    public virtual Statomobilio? StatomobilioNavigation { get; set; } 
    [ForeignKey("Tipomobilio")]
    public virtual Tipomobilio? TipomobilioNavigation { get; set; } 
}
