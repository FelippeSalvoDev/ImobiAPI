using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ImobiAPI.Infrastructure.Persistence.Seeds;


namespace ImobiAPI.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Municipio> Municipios => Set<Municipio>();
    public DbSet<AliquotaITBI> AliquotasITBI => Set<AliquotaITBI>();
    public DbSet<TabelaEmolumentos> TabelasEmolumentos => Set<TabelaEmolumentos>();
    public DbSet<FaixaEmolumento> FaixasEmolumentos => Set<FaixaEmolumento>();
    public DbSet<ApiKey> ApiKeys => Set<ApiKey>();
    public DbSet<UsoApiKey> UsoApiKeys => Set<UsoApiKey>();

    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        CapitaisSeeder.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}