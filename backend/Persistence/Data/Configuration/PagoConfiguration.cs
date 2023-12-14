using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PagoConfiguration : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("pago");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdFormaPagoFk, "id_forma_pago_fk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.FechaPago).HasColumnName("fecha_pago");
            builder.Property(e => e.IdFormaPagoFk).HasColumnName("id_forma_pago_fk");
            builder.Property(e => e.Total).HasColumnName("total");

            builder.HasOne(d => d.IdFormaPagoFkNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdFormaPagoFk)
                .HasConstraintName("pago_ibfk_1");
        }
    }
}