using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class CiudadDto : BaseDto
{
    public string Nombre { get; set; }

    public int IdDepartamentoFk { get; set; }
}
