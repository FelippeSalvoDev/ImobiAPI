using ImobiAPI.API.Middleware;
using ImobiAPI.Application.Interfaces;
using ImobiAPI.Application.UseCases.CalcularCustos;
using ImobiAPI.Application.UseCases.ConsultarMunicipio;
using ImobiAPI.Domain.Services;
using ImobiAPI.Infrastructure.Cache;
using ImobiAPI.Infrastructure.Persistence;
using ImobiAPI.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using StackExchange.Redis;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")!));

builder.Services.AddScoped<ICacheService, RedisCacheService>();

builder.Services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();
builder.Services.AddScoped<ITabelaEmolumentosRepository, TabelaEmolumentosRepository>();

builder.Services.AddScoped<CalculadorCustosService>();

builder.Services.AddScoped<CalcularCustosUseCase>();
builder.Services.AddScoped<ConsultarMunicipioUseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapScalarApiReference(options =>
    {
        options.WithOpenApiRoutePattern("/swagger/v1/swagger.json");
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();
app.MapControllers();

app.Run();