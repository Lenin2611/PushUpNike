using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProducto
    {
        private readonly NikeContext _context;

        public ProductoRepository(NikeContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Producto> GetProductoByTipo(string tipoprod)
        {
            return (from producto in _context.Productos
                    join tipo in _context.TipoProductos on producto.IdTipoProductoFk equals tipo.Id
                    where tipo.Descripcion == tipoprod
                    select producto).AsQueryable();
        }

        public IQueryable<Producto> GetProductoByEstado()
        {
            return (from producto in _context.Productos
                    join estado in _context.Estados on producto.IdEstadoFk equals estado.Id
                    where estado.Descripcion == "Carrito"
                    select producto).AsQueryable();
        }
    }
}