using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("cliente");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdDireccionFk, "id_direccion_fk");

            builder.HasIndex(e => e.IdPersona, "id_persona").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            builder.Property(e => e.IdDireccionFk).HasColumnName("id_direccion_fk");
            builder.Property(e => e.IdPersona).HasColumnName("id_persona");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            builder.Property(e => e.Telefono).HasColumnName("telefono");

            builder.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdDireccionFk)
                .HasConstraintName("cliente_ibfk_1");
        }
    }
}