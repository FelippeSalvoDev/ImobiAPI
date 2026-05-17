using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImobiAPI.Infrastructure.Persistence.Configurations;

public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder)
    {
        builder.ToTable("municipios");
        builder.HasKey(m => m.Id);

        builder.OwnsOne(m => m.CodigoIBGE, codigoIBGE =>
        {
            codigoIBGE.Property(c => c.Valor)
                .HasColumnName("codigo_ibge")
                .HasMaxLength(7)
                .IsRequired();

            codigoIBGE.HasIndex(c => c.Valor).IsUnique();
        });

        builder.Property(m => m.Nome)
            .HasColumnName("nome")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(m => m.UF)
            .HasColumnName("uf")
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(m => m.Populacao)
            .HasColumnName("populacao");

        builder.Property(m => m.Suportado)
            .HasColumnName("suportado")
            .HasDefaultValue(false);

        builder.Property(m => m.AtualizadoEm)
            .HasColumnName("atualizado_em");

        builder.HasOne(m => m.AliquotaITBI)
            .WithOne()
            .HasForeignKey<AliquotaITBI>(a => a.MunicipioId);
    }
}