using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImobiAPI.Infrastructure.Persistence.Configurations;

public class AliquotaITBIConfiguration : IEntityTypeConfiguration<AliquotaITBI>
{
    public void Configure(EntityTypeBuilder<AliquotaITBI> builder)
    {
        builder.ToTable("aliquotas_itbi");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.MunicipioId)
            .HasColumnName("municipio_id")
            .IsRequired();

        builder.Property(a => a.Aliquota)
            .HasColumnName("aliquota")
            .HasPrecision(5, 4)
            .IsRequired();

        builder.Property(a => a.AliquotaFinanciado)
            .HasColumnName("aliquota_financiado")
            .HasPrecision(5, 4);

        builder.Property(a => a.LimiteIsencao)
            .HasColumnName("limite_isencao")
            .HasPrecision(15, 2);

        builder.Property(a => a.FonteLegal)
            .HasColumnName("fonte_legal")
            .HasMaxLength(200);

        builder.Property(a => a.AnoVigencia)
            .HasColumnName("ano_vigencia")
            .IsRequired();

        builder.Property(a => a.Ativo)
            .HasColumnName("ativo")
            .HasDefaultValue(true);
    }
}