using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrdenPedido : BaseEntity
{


    public int? IdOrdenFk { get; set; }

    public int? IdPedidoFk { get; set; }

    public virtual Orden IdOrdenFkNavigation { get; set; }

    public virtual Pedido IdPedidoFkNavigation { get; set; }
}
