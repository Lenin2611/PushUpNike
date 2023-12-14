using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("orden");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdProductoFk, "id_producto_fk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.IdProductoFk).HasColumnName("id_producto_fk");

            builder.HasOne(d => d.IdProductoFkNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.IdProductoFk)
                .HasConstraintName("orden_ibfk_1");
        }
    }
}