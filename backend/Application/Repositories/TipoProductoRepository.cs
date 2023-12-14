using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class TipoProductoRepository : GenericRepository<TipoProducto>, ITipoProducto
    {
        private readonly NikeContext _context;

        public TipoProductoRepository(NikeContext context) : base(context)
        {
            _context = context;
        }
    }
}