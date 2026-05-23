using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Constants;
using ImobiAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ImobiAPI.Application.UseCases.CriarApiKey;

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
            return Unauthorized(new { erro = "Chave de admin inválida." });

        if (request.Plano != Planos.Gratuito && request.Plano != Planos.Pro)
            return BadRequest(new { erro = $"Plano inválido. Use '{Planos.Gratuito}' ou '{Planos.Pro}'." });

        var apiKey = new ApiKey(request.Email, request.Plano);
        await _repository.AdicionarAsync(apiKey);

        return Ok(new
        {
            chave = apiKey.Chave,
            email = apiKey.Email,
            plano = apiKey.Plano,
            limiteDiario = apiKey.LimiteDiario
        });
    }
}

public record CriarApiKeyRequest(string Email, string Plano);