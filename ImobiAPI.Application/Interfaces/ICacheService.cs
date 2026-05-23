namespace ImobiAPI.Application.Interfaces;

public interface ICacheService
{
    Task<T?> ObterAsync<T>(string chave);
    Task SalvarAsync<T>(string chave, T valor, TimeSpan? expiracao = null);
    Task RemoverAsync(string chave);
}

