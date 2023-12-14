using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("pedido");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdClienteFk, "id_cliente_fk");

            builder.HasIndex(e => e.IdPagoFk, "id_pago_fk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdClienteFk).HasColumnName("id_cliente_fk");
            builder.Property(e => e.IdPagoFk).HasColumnName("id_pago_fk");

            builder.HasOne(d => d.IdClienteFkNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdClienteFk)
                .HasConstraintName("pedido_ibfk_1");

            builder.HasOne(d => d.IdPagoFkNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdPagoFk)
                .HasConstraintName("pedido_ibfk_2");
        }
    }
}