using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NikeContext _context;

        private ICiudad _Ciudades; // 2611
        private ICliente _Clientes;
        private IDepartamento _Departamentos;
        private IDireccion _Direcciones;
        private IEstado _Estados;
        private IFormaPago _FormaPagos;
        private IOrden _Ordenes;
        private IOrdenPedido _OrdenPedidos;
        private IPago _Pagos;
        private IPais _Paises;
        private IPedido _Pedidos;
        private IProducto _Productos;
        private IRol _Rols;
        private ITipoProducto _TipoProductos;
        private IUser _Users;

        public UnitOfWork(NikeContext context)
        {
            _context = context;
        }

        public ICiudad Ciudades // 2611
        {
            get
            {
                if (_Ciudades == null)
                {
                    _Ciudades = new CiudadRepository(_context);
                }
                return _Ciudades;
            }
        }
        public ICliente Clientes // 2611
        {
            get
            {
                if (_Clientes == null)
                {
                    _Clientes = new ClienteRepository(_context);
                }
                return _Clientes;
            }
        }
        public IDepartamento Departamentos // 2611
        {
            get
            {
                if (_Departamentos == null)
                {
                    _Departamentos = new DepartamentoRepository(_context);
                }
                return _Departamentos;
            }
        }
        public IDireccion Direcciones // 2611
        {
            get
            {
                if (_Direcciones == null)
                {
                    _Direcciones = new DireccionRepository(_context);
                }
                return _Direcciones;
            }
        }
        public IEstado Estados // 2611
        {
            get
            {
                if (_Estados == null)
                {
                    _Estados = new EstadoRepository(_context);
                }
                return _Estados;
            }
        }
        public IFormaPago FormaPagos // 2611
        {
            get
            {
                if (_FormaPagos == null)
                {
                    _FormaPagos = new FormaPagoRepository(_context);
                }
                return _FormaPagos;
            }
        }
        public IOrden Ordenes // 2611
        {
            get
            {
                if (_Ordenes == null)
                {
                    _Ordenes = new OrdenRepository(_context);
                }
                return _Ordenes;
            }
        }
        public IOrdenPedido OrdenPedidos // 2611
        {
            get
            {
                if (_OrdenPedidos == null)
                {
                    _OrdenPedidos = new OrdenPedidoRepository(_context);
                }
                return _OrdenPedidos;
            }
        }
        public IPago Pagos // 2611
        {
            get
            {
                if (_Pagos == null)
                {
                    _Pagos = new PagoRepository(_context);
                }
                return _Pagos;
            }
        }
        public IPais Paises // 2611
        {
            get
            {
                if (_Paises == null)
                {
                    _Paises = new PaisRepository(_context);
                }
                return _Paises;
            }
        }
        public IPedido Pedidos // 2611
        {
            get
            {
                if (_Pedidos == null)
                {
                    _Pedidos = new PedidoRepository(_context);
                }
                return _Pedidos;
            }
        }
        public IProducto Productos // 2611
        {
            get
            {
                if (_Productos == null)
                {
                    _Productos = new ProductoRepository(_context);
                }
                return _Productos;
            }
        }
        public IRol Rols // 2611
        {
            get
            {
                if (_Rols == null)
                {
                    _Rols = new RolRepository(_context);
                }
                return _Rols;
            }
        }
        public ITipoProducto TipoProductos // 2611
        {
            get
            {
                if (_TipoProductos == null)
                {
                    _TipoProductos = new TipoProductoRepository(_context);
                }
                return _TipoProductos;
            }
        }
        public IUser Users // 2611
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(_context);
                }
                return _Users;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveAsync() // 2611
        {
            return _context.SaveChangesAsync();
        }
    }
}