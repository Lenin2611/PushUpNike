using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("ciudad");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdDepartamentoFk, "id_departamento_fk");

            builder.HasIndex(e => e.Nombre, "nombre").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdDepartamentoFk).HasColumnName("id_departamento_fk");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            builder.HasOne(d => d.IdDepartamentoFkNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdDepartamentoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ciudad_ibfk_1");
        }
    }
}