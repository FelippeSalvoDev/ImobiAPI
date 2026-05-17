using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Entities;
using ImobiAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ImobiAPI.Infrastructure.Persistence.Repositories;

public class TabelaEmolumentosRepository : ITabelaEmolumentosRepository
{
    private readonly AppDbContext _context;

    public TabelaEmolumentosRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TabelaEmolumentos?> ObterPorUFETipoAsync(string uf, TipoAto tipoAto)
    {
        return await _context.TabelasEmolumentos
            .Include(t => t.Faixas)
            .FirstOrDefaultAsync(t =>
                t.UF == uf.ToUpper() &&
                t.TipoAto == tipoAto &&
                t.Ativo);
    }
}