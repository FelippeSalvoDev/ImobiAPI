using ImobiAPI.Application.DTOs;
using ImobiAPI.Application.UseCases.CalcularCustos;
using Microsoft.AspNetCore.Mvc;

namespace ImobiAPI.API.Controllers;

[ApiController]
[Route("v1/calcular")]
public class CalculoController : ControllerBase
{
    private readonly CalcularCustosUseCase _useCase;

    public CalculoController(CalcularCustosUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public async Task<IActionResult> Calcular([FromBody] CalcularCustosRequest request)
    {
        try
        {
            var resultado = await _useCase.ExecutarAsync(request);
            return Ok(ApiResponse<CalcularCustosResponse>.Ok(resultado));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ApiResponse<CalcularCustosResponse>.Falha("IM001", ex.Message));
        }
        catch (InvalidOperationException ex)
        {
            return UnprocessableEntity(ApiResponse<CalcularCustosResponse>.Falha("IM002", ex.Message));
        }
    }
}