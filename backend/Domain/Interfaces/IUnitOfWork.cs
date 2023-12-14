using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public ICiudad Ciudades { get; } // 2611
        public ICliente Clientes { get; }
        public IDepartamento Departamentos { get; }
        public IDireccion Direcciones { get; }
        public IFormaPago FormaPagos { get; }
        public IOrden Ordenes { get; }
        public IOrdenPedido OrdenPedidos { get; }
        public IPago Pagos { get; }
        public IPais Paises { get; }
        public IPedido Pedidos { get; }
        public IProducto Productos { get; }
        public IRol Rols { get; }
        public ITipoProducto TipoProductos { get; }
        public IUser Users { get; }

        Task<int> SaveAsync(); // 2611
    }
}