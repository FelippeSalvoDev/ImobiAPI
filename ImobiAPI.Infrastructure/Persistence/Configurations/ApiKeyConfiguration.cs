using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImobiAPI.Infrastructure.Persistence.Configurations;

public class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
{
    public void Configure(EntityTypeBuilder<ApiKey> builder)
    {
        builder.ToTable("api_keys");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Chave)
            .HasColumnName("chave")
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(a => a.Email)
            .HasColumnName("email")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.Plano)
            .HasColumnName("plano")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(a => a.UsuarioId)
       .HasColumnName("usuario_id");

        builder.Property(a => a.LimiteDiario)
            .HasColumnName("limite_diario")
            .IsRequired();

        builder.Property(a => a.Ativa)
            .HasColumnName("ativa")
            .HasDefaultValue(true);

        builder.Property(a => a.CriadoEm)
            .HasColumnName("criado_em");

        builder.HasIndex(a => a.Chave).IsUnique();
    }
}