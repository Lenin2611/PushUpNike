using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProducto : IGenericRepository<Producto>
    {
        IQueryable<Producto> GetProductoByTipo(string tipoprod);
        IQueryable<Producto> GetProductoByEstado();
    }
}