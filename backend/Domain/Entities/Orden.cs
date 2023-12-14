using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Orden : BaseEntity
{


    public int? Cantidad { get; set; }

    public int? IdProductoFk { get; set; }

    public virtual Producto IdProductoFkNavigation { get; set; }

    public virtual ICollection<OrdenPedido> OrdenPedidos { get; set; } = new List<OrdenPedido>();
}
