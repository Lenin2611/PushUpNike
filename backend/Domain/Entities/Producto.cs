using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Producto : BaseEntity
{


    public string Nombre { get; set; }

    public string Imagen { get; set; }

    public string Talla { get; set; }

    public int? StockMin { get; set; }

    public int? StockActual { get; set; }

    public int? StockMax { get; set; }

    public double? Precio { get; set; }

    public int? IdTipoProductoFk { get; set; }

    public int? IdEstadoFk { get; set; }

    public virtual TipoProducto IdTipoProductoFkNavigation { get; set; }

    public virtual Estado IdEstadoFkNavigation { get; set; }

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
