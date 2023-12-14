using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TipoProducto : BaseEntity
{


    public string Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
