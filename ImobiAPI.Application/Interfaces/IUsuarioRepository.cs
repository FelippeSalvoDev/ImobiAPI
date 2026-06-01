using ImobiAPI.Domain.Entities;

namespace ImobiAPI.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorGoogleIdAsync(string googleId);
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task<Usuario?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Usuario usuario);
    Task AtualizarAsync(Usuario usuario);
}