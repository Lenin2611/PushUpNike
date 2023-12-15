using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("estado");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.Descripcion, "descripcion").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
        }
    }
}