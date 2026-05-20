using ImobiAPI.Application.UseCases.ConsultarMunicipio;
using Microsoft.AspNetCore.Mvc;

namespace ImobiAPI.API.Controllers;

[ApiController]
[Route("v1/municipios")]
public class MunicipioController : ControllerBase
{
    private readonly ConsultarMunicipioUseCase _useCase;

    public MunicipioController(ConsultarMunicipioUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var resultado = await _useCase.ExecutarAsync();
        return Ok(resultado);
    }
}