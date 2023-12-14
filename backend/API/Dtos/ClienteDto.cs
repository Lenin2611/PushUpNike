using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class ClienteDto : BaseDto
{
    public int? IdPersona { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Email { get; set; }

    public int? Telefono { get; set; }

    public int? IdDireccionFk { get; set; }
}
