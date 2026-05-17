using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImobiAPI.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Municipio> Municipios => Set<Municipio>();
    public DbSet<AliquotaITBI> AliquotasITBI => Set<AliquotaITBI>();
    public DbSet<TabelaEmolumentos> TabelasEmolumentos => Set<TabelaEmolumentos>();
    public DbSet<FaixaEmolumento> FaixasEmolumentos => Set<FaixaEmolumento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}