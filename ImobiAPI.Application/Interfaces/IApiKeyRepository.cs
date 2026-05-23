using ImobiAPI.Domain.Entities;

namespace ImobiAPI.Application.Interfaces;

public interface IApiKeyRepository
{
    Task<ApiKey?> ObterPorChaveAsync(string chave);
    Task<int> ContarChamadasHojeAsync(int apiKeyId);
    Task AdicionarAsync(ApiKey apiKey);
}