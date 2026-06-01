using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImobiAPI.Infrastructure.Persistence.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.GoogleId)
            .HasColumnName("google_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.Nome)
            .HasColumnName("nome")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.FotoPerfil)
            .HasColumnName("foto_perfil")
            .HasMaxLength(500);

        builder.Property(u => u.CriadoEm)
            .HasColumnName("criado_em");

        builder.HasIndex(u => u.GoogleId).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasMany(u => u.ApiKeys)
            .WithOne()
            .HasForeignKey(a => a.UsuarioId);
    }
}