using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Direccion : BaseEntity
{


    public string TipoVia { get; set; }

    public short? NumeroPrincipal { get; set; }

    public string LetraPrincipal { get; set; }

    public string Bis { get; set; }

    public string LetraSecundaria { get; set; }

    public string CardinalPrimario { get; set; }

    public short? NumeroSecundario { get; set; }

    public string CardinalSecundario { get; set; }

    public string Complemento { get; set; }

    public int? IdCiudadFk { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Ciudad IdCiudadFkNavigation { get; set; }
}
