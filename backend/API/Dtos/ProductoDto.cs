using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class ProductoDto : BaseDto
{
    public string Nombre { get; set; }

    public string Imagen { get; set; }

    public string Talla { get; set; }

    public int? StockMin { get; set; }

    public int? StockActual { get; set; }

    public int? StockMax { get; set; }

    public double? Precio { get; set; }

    public int? IdTipoProductoFk { get; set; }
}
