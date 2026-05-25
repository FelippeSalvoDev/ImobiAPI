using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Constants;
using ImobiAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ImobiAPI.Application.UseCases.CriarApiKey;
using ImobiAPI.Application.DTOs;

namespace ImobiAPI.API.Controllers;

[ApiController]
[Route("v1/api-keys")]
public class ApiKeyController : ControllerBase
{
    private readonly IApiKeyRepository _repository;
    private readonly IConfiguration _configuration;

    public ApiKeyController(IApiKeyRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(
        [FromHeader(Name = "X-Admin-Key")] string adminKey,
        [FromBody] CriarApiKeyRequest request)
    {
        var chaveAdmin = _configuration.GetValue<string>("ApiKey:ChaveAdmin");

        if (adminKey != chaveAdmin)
            return Unauthorized(ApiResponse<object>.Falha("IM004", "Chave de admin inválida."));

        if (request.Plano != Planos.Gratuito && request.Plano != Planos.Pro)
            return BadRequest(ApiResponse<object>.Falha("IM003", $"Plano inválido. Use '{Planos.Gratuito}' ou '{Planos.Pro}'."));

        var apiKey = new ApiKey(request.Email, request.Plano);
        await _repository.AdicionarAsync(apiKey);

        return Ok(ApiResponse<object>.Ok(new
        {
            chave = apiKey.Chave,
            email = apiKey.Email,
            plano = apiKey.Plano,
            limiteDiario = apiKey.LimiteDiario
        }));
    }
}