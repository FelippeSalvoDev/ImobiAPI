using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImobiAPI.Infrastructure.Persistence.Repositories;

public class MunicipioRepository : IMunicipioRepository
{
    private readonly AppDbContext _context;

    public MunicipioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Municipio?> ObterPorCodigoIBGEAsync(string codigoIBGE)
    {
        return await _context.Municipios
            .Include(m => m.AliquotaITBI)
            .FirstOrDefaultAsync(m => m.CodigoIBGE.Valor == codigoIBGE);
    }

    public async Task<Municipio?> ObterPorIdAsync(int id)
    {
        return await _context.Municipios
            .Include(m => m.AliquotaITBI)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Municipio>> ListarSuportadosAsync()
    {
        return await _context.Municipios
            .Where(m => m.Suportado)
            .OrderBy(m => m.Nome)
            .ToListAsync();
    }

    public async Task AdicionarAsync(Municipio municipio)
    {
        await _context.Municipios.AddAsync(municipio);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Municipio municipio)
    {
        _context.Municipios.Update(municipio);
        await _context.SaveChangesAsync();
    }
}