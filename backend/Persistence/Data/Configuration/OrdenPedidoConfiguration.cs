using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OrdenPedidoConfiguration : IEntityTypeConfiguration<OrdenPedido>
    {
        public void Configure(EntityTypeBuilder<OrdenPedido> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("orden_pedido");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdOrdenFk, "id_orden_fk");

            builder.HasIndex(e => e.IdPedidoFk, "id_pedido_fk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdOrdenFk).HasColumnName("id_orden_fk");
            builder.Property(e => e.IdPedidoFk).HasColumnName("id_pedido_fk");

            builder.HasOne(d => d.IdOrdenFkNavigation).WithMany(p => p.OrdenPedidos)
                .HasForeignKey(d => d.IdOrdenFk)
                .HasConstraintName("orden_pedido_ibfk_1");

            builder.HasOne(d => d.IdPedidoFkNavigation).WithMany(p => p.OrdenPedidos)
                .HasForeignKey(d => d.IdPedidoFk)
                .HasConstraintName("orden_pedido_ibfk_2");
        }
    }
}