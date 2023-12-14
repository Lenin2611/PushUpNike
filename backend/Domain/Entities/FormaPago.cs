using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class FormaPago : BaseEntity
{


    public string Nombre { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
