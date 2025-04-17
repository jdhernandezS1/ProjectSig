using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace armadieti2.Models;

public partial class Movimento
{
    [Key]
    public int Idmovimento { get; set; }
    [Required]
    public int Idnoleggio { get; set; }
    [Required]
    public decimal Cauzione { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public int Pagamento { get; set; }
    
    [ForeignKey("Idnoleggio")]
    public virtual Noleggio? IdnoleggioNavigation { get; set; } 
    
    [ForeignKey("Pagamento")]
    public virtual Tipopagamento? PagamentoNavigation { get; set; } 
}
