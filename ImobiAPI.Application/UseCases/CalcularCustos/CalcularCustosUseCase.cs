using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Enums;
using ImobiAPI.Domain.Services;

namespace ImobiAPI.Application.UseCases.CalcularCustos;

public class CalcularCustosUseCase
{
    private readonly IMunicipioRepository _municipioRepository;
    private readonly ITabelaEmolumentosRepository _tabelaEmolumentosRepository;
    private readonly CalculadorCustosService _calculadorCustosService;
    private readonly ICacheService _cacheService;

    public CalcularCustosUseCase(
        IMunicipioRepository municipioRepository,
        ITabelaEmolumentosRepository tabelaEmolumentosRepository,
        CalculadorCustosService calculadorCustosService, ICacheService cacheService)
    {
        _municipioRepository = municipioRepository;
        _tabelaEmolumentosRepository = tabelaEmolumentosRepository;
        _calculadorCustosService = calculadorCustosService;
        _cacheService = cacheService;
    }

    public async Task<CalcularCustosResponse> ExecutarAsync(CalcularCustosRequest request)
    {
        var municipio = await _cacheService.ObterAsync<Domain.Entities.Municipio>($"municipio:{request.CodigoIBGE}");

        if (municipio is null)
        {
            municipio = await _municipioRepository.ObterPorCodigoIBGEAsync(request.CodigoIBGE)
                ?? throw new KeyNotFoundException($"Município com código IBGE {request.CodigoIBGE} não encontrado.");

            await _cacheService.SalvarAsync($"municipio:{request.CodigoIBGE}", municipio);
        }

        if (!municipio.Suportado)
            throw new InvalidOperationException($"Município {municipio.Nome} ainda não tem dados cadastrados.");

        var tabelaEscritura = await _cacheService.ObterAsync<Domain.Entities.TabelaEmolumentos>($"tabela:{municipio.UF}:Escritura");

        if (tabelaEscritura is null)
        {
            tabelaEscritura = await _tabelaEmolumentosRepository.ObterPorUFETipoAsync(municipio.UF, TipoAto.Escritura)
                ?? throw new InvalidOperationException($"Tabela de emolumentos de escritura não encontrada para {municipio.UF}.");

            await _cacheService.SalvarAsync($"tabela:{municipio.UF}:Escritura", tabelaEscritura);
        }

        var tabelaRegistro = await _cacheService.ObterAsync<Domain.Entities.TabelaEmolumentos>($"tabela:{municipio.UF}:Registro");

        if (tabelaRegistro is null)
        {
            tabelaRegistro = await _tabelaEmolumentosRepository.ObterPorUFETipoAsync(municipio.UF, TipoAto.Registro)
                ?? throw new InvalidOperationException($"Tabela de emolumentos de registro não encontrada para {municipio.UF}.");

            await _cacheService.SalvarAsync($"tabela:{municipio.UF}:Registro", tabelaRegistro);
        }

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