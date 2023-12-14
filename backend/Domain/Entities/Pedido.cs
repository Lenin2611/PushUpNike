using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pedido : BaseEntity
{

    public int? IdPagoFk { get; set; }

    public int? IdClienteFk { get; set; }

    public virtual Cliente IdClienteFkNavigation { get; set; }

    public virtual Pago IdPagoFkNavigation { get; set; }

    public virtual ICollection<OrdenPedido> OrdenPedidos { get; set; } = new List<OrdenPedido>();
}
