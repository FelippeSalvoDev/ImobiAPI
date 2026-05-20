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
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(ApiKeyHeader, out var apiKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { erro = "API Key não informada." });
            return;
        }

        // TODO: buscar e validar API Key no banco de dados
        var chaveValida = context.RequestServices
            .GetRequiredService<IConfiguration>()
            .GetValue<string>("ApiKey:ChaveDesenvolvimento");

        if (apiKey != chaveValida)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { erro = "API Key inválida." });
            return;
        }

        await _next(context);
    }
}