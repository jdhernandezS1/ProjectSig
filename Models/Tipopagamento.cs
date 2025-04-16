using System;
using System.Collections.Generic;

namespace armadieti2.Models;

public partial class Tipopagamento
{
    public string Pagamento { get; set; } = null!;

    public virtual ICollection<Movimento> Movimentos { get; set; } = new List<Movimento>();
}
