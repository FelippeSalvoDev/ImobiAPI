using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImobiAPI.Infrastructure.Persistence.Repositories;

public class ApiKeyRepository : IApiKeyRepository
{
    private readonly AppDbContext _context;

    public ApiKeyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiKey?> ObterPorChaveAsync(string chave)
    {
        return await _context.ApiKeys
            .FirstOrDefaultAsync(a => a.Chave == chave && a.Ativa);
    }

    public async Task<int> ContarChamadasHojeAsync(int apiKeyId)
    {
        var hoje = DateTime.UtcNow.Date;
        return await _context.UsoApiKeys
            .CountAsync(u => u.ApiKeyId == apiKeyId && u.CriadoEm >= hoje);
    }

    public async Task AdicionarAsync(ApiKey apiKey)
    {
        await _context.ApiKeys.AddAsync(apiKey);
        await _context.SaveChangesAsync();
    }
}