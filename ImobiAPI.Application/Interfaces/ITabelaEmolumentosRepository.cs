using ImobiAPI.Domain.Entities;
using ImobiAPI.Domain.Enums;

namespace ImobiAPI.Application.Interfaces;

public interface ITabelaEmolumentosRepository
{
    Task<TabelaEmolumentos?> ObterPorUFETipoAsync(string uf, TipoAto tipoAto);
}