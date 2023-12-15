using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using System.Reflection;

namespace Persistence.Data;

public partial class NikeContext : DbContext
{
    public NikeContext()
    {
    }

    public NikeContext(DbContextOptions<NikeContext> options) : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Direccion> Direcciones { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<FormaPago> FormaPagos { get; set; }

    public virtual DbSet<Orden> Ordenes { get; set; }

    public virtual DbSet<OrdenPedido> OrdenPedidos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pais> Paises { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoProducto> TipoProductos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRol> UserRols { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) // 2611
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
