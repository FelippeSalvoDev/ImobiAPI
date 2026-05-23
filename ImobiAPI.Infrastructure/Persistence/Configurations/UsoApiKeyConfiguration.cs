using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImobiAPI.Infrastructure.Persistence.Configurations;

public class UsoApiKeyConfiguration : IEntityTypeConfiguration<UsoApiKey>
{
    public void Configure(EntityTypeBuilder<UsoApiKey> builder)
    {
        builder.ToTable("uso_api_keys");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.ApiKeyId)
            .HasColumnName("api_key_id")
            .IsRequired();

        builder.Property(u => u.Endpoint)
            .HasColumnName("endpoint")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.StatusCode)
            .HasColumnName("status_code")
            .IsRequired();

        builder.Property(u => u.CriadoEm)
            .HasColumnName("criado_em");

        builder.HasIndex(u => new { u.ApiKeyId, u.CriadoEm });

        builder.HasOne<ApiKey>()
            .WithMany()
            .HasForeignKey(u => u.ApiKeyId);
    }
}