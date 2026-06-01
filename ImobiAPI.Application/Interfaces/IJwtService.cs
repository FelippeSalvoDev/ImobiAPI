using ImobiAPI.Domain.Entities;

namespace ImobiAPI.Application.Interfaces;

public interface IJwtService
{
    string GerarToken(Usuario usuario);
    int? ObterUsuarioId(string token);
}