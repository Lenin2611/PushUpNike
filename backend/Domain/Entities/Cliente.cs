using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Cliente : BaseEntity
{


    public int? IdPersona { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Email { get; set; }

    public int? Telefono { get; set; }

    public int? IdDireccionFk { get; set; }

    public virtual Direccion IdDireccionFkNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
