using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("direccion");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdCiudadFk, "id_ciudad_fk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Bis)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("bis");
            builder.Property(e => e.CardinalPrimario)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinal_primario");
            builder.Property(e => e.CardinalSecundario)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinal_secundario");
            builder.Property(e => e.Complemento)
                .HasMaxLength(50)
                .HasColumnName("complemento");
            builder.Property(e => e.IdCiudadFk).HasColumnName("id_ciudad_fk");
            builder.Property(e => e.LetraPrincipal)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letra_principal");
            builder.Property(e => e.LetraSecundaria)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letra_secundaria");
            builder.Property(e => e.NumeroPrincipal).HasColumnName("numero_principal");
            builder.Property(e => e.NumeroSecundario).HasColumnName("numero_secundario");
            builder.Property(e => e.TipoVia)
                .HasMaxLength(50)
                .HasColumnName("tipo_via");

            builder.HasOne(d => d.IdCiudadFkNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdCiudadFk)
                .HasConstraintName("direccion_ibfk_1");
        }
    }
}