using ImobiAPI.Application.DTOs;
using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Entities;
using ImobiAPI.Infrastructure.Persistence;

namespace ImobiAPI.API.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string ApiKeyHeader = "X-Api-Key";

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger") ||
             context.Request.Path.StartsWithSegments("/scalar") ||
             context.Request.Path.StartsWithSegments("/openapi") ||
             context.Request.Path.StartsWithSegments("/v1/api-keys"))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(ApiKeyHeader, out var chave))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(ApiResponse<object>.Falha("IM006", "API Key não informada."));
            return;
        }

        var apiKeyRepository = context.RequestServices.GetRequiredService<IApiKeyRepository>();
        var apiKey = await apiKeyRepository.ObterPorChaveAsync(chave!);

        if (apiKey is null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(ApiResponse<object>.Falha("IM005", "API Key inválida."));
            return;
        }

        var totalHoje = await apiKeyRepository.ContarChamadasHojeAsync(apiKey.Id);

        if (!apiKey.PodeRealizarChamada(totalHoje))
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            await context.Response.WriteAsJsonAsync(ApiResponse<object>.Falha("IM007", $"Limite diário de {apiKey.LimiteDiario} requisições atingido."));
            return;
        }

        context.Items["ApiKey"] = apiKey;

        await _next(context);

        var uso = new UsoApiKey(apiKey.Id, context.Request.Path, context.Response.StatusCode);
        var dbContext = context.RequestServices.GetRequiredService<AppDbContext>();
        await dbContext.UsoApiKeys.AddAsync(uso);
        await dbContext.SaveChangesAsync();
    }
}
