using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("producto");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdTipoProductoFk, "id_tipo_producto_fk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdTipoProductoFk).HasColumnName("id_tipo_producto_fk");
            builder.Property(e => e.Imagen)
                .HasMaxLength(200)
                .HasColumnName("imagen");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            builder.Property(e => e.Precio).HasColumnName("precio");
            builder.Property(e => e.StockActual).HasColumnName("stock_actual");
            builder.Property(e => e.StockMax).HasColumnName("stock_max");
            builder.Property(e => e.StockMin).HasColumnName("stock_min");
            builder.Property(e => e.Talla)
                .HasMaxLength(5)
                .HasColumnName("talla");

            builder.HasOne(d => d.IdTipoProductoFkNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdTipoProductoFk)
                .HasConstraintName("producto_ibfk_1");
        }
    }
}