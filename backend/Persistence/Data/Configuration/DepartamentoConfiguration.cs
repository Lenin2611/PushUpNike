using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("departamento");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdPaisFk, "id_pais_fk");

            builder.HasIndex(e => e.Nombre, "nombre").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdPaisFk).HasColumnName("id_pais_fk");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            builder.HasOne(d => d.IdPaisFkNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPaisFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("departamento_ibfk_1");
        }
    }
}