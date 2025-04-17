using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models;

public partial class Tipopagamento
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Pagamento { get; set; } = null!;

    public virtual ICollection<Movimento> Movimentos { get; set; } = new List<Movimento>();
}
