using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImobiAPI.Infrastructure.Persistence.Configurations;

public class FaixaEmolumentoConfiguration : IEntityTypeConfiguration<FaixaEmolumento>
{
    public void Configure(EntityTypeBuilder<FaixaEmolumento> builder)
    {
        builder.ToTable("faixas_emolumentos");
        builder.HasKey(f => f.Id);

        builder.Property(f => f.TabelaEmolumentosId)
            .HasColumnName("tabela_id")
            .IsRequired();

        builder.Property(f => f.ValorMinimo)
            .HasColumnName("valor_minimo")
            .HasPrecision(15, 2)
            .IsRequired();

        builder.Property(f => f.ValorMaximo)
            .HasColumnName("valor_maximo")
            .HasPrecision(15, 2);

        builder.Property(f => f.ValorFixo)
            .HasColumnName("valor_fixo")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(f => f.PercentualExcedente)
            .HasColumnName("percentual_excedente")
            .HasPrecision(6, 4);

        builder.Property(f => f.TipoAto)
            .HasColumnName("tipo_ato")
            .HasConversion<string>()
            .IsRequired();
    }
}