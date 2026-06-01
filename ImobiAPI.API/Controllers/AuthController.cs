using ImobiAPI.Application.DTOs;
using ImobiAPI.Application.UseCases.AuthGoogle;
using Microsoft.AspNetCore.Mvc;

namespace ImobiAPI.API.Controllers;

[ApiController]
[Route("v1/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthGoogleUseCase _useCase;

    public AuthController(AuthGoogleUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("google")]
    public async Task<IActionResult> Google([FromBody] AuthGoogleRequest request)
    {
        try
        {
            var resultado = await _useCase.ExecutarAsync(request);
            return Ok(ApiResponse<AuthGoogleResponse>.Ok(resultado));
        }
        catch (Exception ex)
        {
            return Unauthorized(ApiResponse<AuthGoogleResponse>.Falha("IM008", ex.Message));
        }
    }
}