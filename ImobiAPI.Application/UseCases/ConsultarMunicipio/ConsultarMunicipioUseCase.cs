using ImobiAPI.Application.Interfaces;

namespace ImobiAPI.Application.UseCases.ConsultarMunicipio;

public class ConsultarMunicipioUseCase
{
	private readonly IMunicipioRepository _municipioRepository;

	public ConsultarMunicipioUseCase(IMunicipioRepository municipioRepository)
	{
		_municipioRepository = municipioRepository;
	}

	public async Task<IEnumerable<ConsultarMunicipioResponse>> ExecutarAsync()
	{
		var municipios = await _municipioRepository.ListarSuportadosAsync();

		return municipios.Select(m => new ConsultarMunicipioResponse(
			CodigoIBGE: m.CodigoIBGE.Valor,
			Nome: m.Nome,
			UF: m.UF,
			AliquotaITBI: m.AliquotaITBI?.Aliquota,
			Suportado: m.Suportado));
	}
}