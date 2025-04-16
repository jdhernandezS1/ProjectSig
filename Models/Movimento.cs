using System;
using System.Collections.Generic;

namespace armadieti2.Models;

public partial class Movimento
{
    public int Idmovimento { get; set; }

    public int Idnoleggio { get; set; }

    public decimal Cauzione { get; set; }

    public DateOnly Data { get; set; }

    public string Pagamento { get; set; } = null!;

    public virtual Noleggio IdnoleggioNavigation { get; set; } = null!;

    public virtual Tipopagamento PagamentoNavigation { get; set; } = null!;
}
