using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("pais");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.Nombre, "nombre").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        }
    }
}