using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pago : BaseEntity
{


    public DateOnly? FechaPago { get; set; }

    public int? Total { get; set; }

    public int? IdFormaPagoFk { get; set; }

    public virtual FormaPago IdFormaPagoFkNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
