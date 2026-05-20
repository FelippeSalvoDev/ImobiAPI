using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Enums;
using ImobiAPI.Domain.Services;

namespace ImobiAPI.Application.UseCases.CalcularCustos;

public class CalcularCustosUseCase
{
    private readonly IMunicipioRepository _municipioRepository;
    private readonly ITabelaEmolumentosRepository _tabelaEmolumentosRepository;
    private readonly CalculadorCustosService _calculadorCustosService;

    public CalcularCustosUseCase(
        IMunicipioRepository municipioRepository,
        ITabelaEmolumentosRepository tabelaEmolumentosRepository,
        CalculadorCustosService calculadorCustosService)
    {
        _municipioRepository = municipioRepository;
        _tabelaEmolumentosRepository = tabelaEmolumentosRepository;
        _calculadorCustosService = calculadorCustosService;
    }

    public async Task<CalcularCustosResponse> ExecutarAsync(CalcularCustosRequest request)
    {
        var municipio = await _municipioRepository.ObterPorCodigoIBGEAsync(request.CodigoIBGE)
            ?? throw new KeyNotFoundException($"Município com código IBGE {request.CodigoIBGE} não encontrado.");

        if (!municipio.Suportado)
            throw new InvalidOperationException($"Município {municipio.Nome} ainda não tem dados cadastrados.");

        var tabelaEscritura = await _tabelaEmolumentosRepository.ObterPorUFETipoAsync(municipio.UF, TipoAto.Escritura)
            ?? throw new InvalidOperationException($"Tabela de emolumentos de escritura não encontrada para {municipio.UF}.");

        var tabelaRegistro = await _tabelaEmolumentosRepository.ObterPorUFETipoAsync(municipio.UF, TipoAto.Registro)
            ?? throw new InvalidOperationException($"Tabela de emolumentos de registro não encontrada para {municipio.UF}.");

        var resultado = _calculadorCustosService.Calcular(
            municipio,
            request.ValorImovel,
            request.Financiado,
            tabelaEscritura,
            tabelaRegistro);

        return new CalcularCustosResponse(
            Municipio: municipio.Nome,
            UF: municipio.UF,
            ValorImovel: resultado.ValorImovel,
            ValorITBI: resultado.ValorITBI,
            AliquotaITBI: resultado.AliquotaITBI,
            ValorEscritura: resultado.ValorEscritura,
            ValorRegistro: resultado.ValorRegistro,
            TotalCustos: resultado.TotalCustos,
            PercentualSobreImovel: resultado.PercentualSobreImovel,
            Isento: resultado.Isento);
    }
}