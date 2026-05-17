using ImobiAPI.Domain.Entities;

namespace ImobiAPI.Application.Interfaces;

public interface IMunicipioRepository
{
    Task<Municipio?> ObterPorCodigoIBGEAsync(string codigoIBGE);
    Task<Municipio?> ObterPorIdAsync(int id);
    Task<IEnumerable<Municipio>> ListarSuportadosAsync();
    Task AdicionarAsync(Municipio municipio);
    Task AtualizarAsync(Municipio municipio);
}