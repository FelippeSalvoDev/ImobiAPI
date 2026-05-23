using ImobiAPI.Application.Interfaces;

namespace ImobiAPI.Application.UseCases.ConsultarMunicipio;

public class ConsultarMunicipioUseCase
{
	private readonly IMunicipioRepository _municipioRepository;
    private readonly ICacheService _cacheService;
    private const string CacheKey = "municipios:suportados";

    public ConsultarMunicipioUseCase(IMunicipioRepository municipioRepository, ICacheService cacheService)
	{
		_municipioRepository = municipioRepository;
        _cacheService = cacheService;
    }

	public async Task<IEnumerable<ConsultarMunicipioResponse>> ExecutarAsync()
	{
        var cached = await _cacheService.ObterAsync<IEnumerable<ConsultarMunicipioResponse>>(CacheKey);

        if (cached is not null)
            return cached;

        var municipios = await _municipioRepository.ListarSuportadosAsync();

		var response = municipios.Select(m => new ConsultarMunicipioResponse(
			CodigoIBGE: m.CodigoIBGE.Valor,
			Nome: m.Nome,
			UF: m.UF,
			AliquotaITBI: m.AliquotaITBI?.Aliquota,
			Suportado: m.Suportado));

        await _cacheService.SalvarAsync(CacheKey, response, TimeSpan.FromHours(12));

        return response;
    }
}