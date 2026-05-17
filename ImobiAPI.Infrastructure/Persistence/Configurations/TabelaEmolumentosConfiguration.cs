using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImobiAPI.Infrastructure.Persistence.Configurations;

public class TabelaEmolumentosConfiguration : IEntityTypeConfiguration<TabelaEmolumentos>
{
    public void Configure(EntityTypeBuilder<TabelaEmolumentos> builder)
    {
        builder.ToTable("tabelas_emolumentos");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.UF)
            .HasColumnName("uf")
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(t => t.AnoVigencia)
            .HasColumnName("ano_vigencia")
            .IsRequired();

        builder.Property(t => t.TipoAto)
            .HasColumnName("tipo_ato")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(t => t.FonteTJ)
            .HasColumnName("fonte_tj")
            .HasMaxLength(200);

        builder.Property(t => t.Ativo)
            .HasColumnName("ativo")
            .HasDefaultValue(true);

        builder.HasMany(t => t.Faixas)
            .WithOne()
            .HasForeignKey(f => f.TabelaEmolumentosId);

        builder.HasIndex(t => new { t.UF, t.AnoVigencia, t.TipoAto }).IsUnique();
    }
}