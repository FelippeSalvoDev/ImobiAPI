using System.Text.Json;
using ImobiAPI.Application.Interfaces;
using StackExchange.Redis;

namespace ImobiAPI.Infrastructure.Cache;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase _database;
    private readonly TimeSpan _expiracaoPadrao = TimeSpan.FromHours(24);

    public RedisCacheService(IConnectionMultiplexer redis)
    { 
        _database = redis.GetDatabase();
    }

    public async Task<T?> ObterAsync<T>(string chave)
    {
        var valor = await _database.StringGetAsync(chave);

        if (valor.IsNullOrEmpty)
            return default;

        return JsonSerializer.Deserialize<T>(valor!);
    }

    public async Task SalvarAsync<T>(string chave, T valor, TimeSpan? expiracao = null)
    {
        var json = JsonSerializer.Serialize(valor);
        await _database.StringSetAsync(chave, json, expiracao ?? _expiracaoPadrao);
    }

    public async Task RemoverAsync(string chave)
    {
        await _database.KeyDeleteAsync(chave);
    }
}

