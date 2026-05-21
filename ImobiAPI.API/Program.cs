using ImobiAPI.API.Middleware;
using ImobiAPI.Application.Interfaces;
using ImobiAPI.Application.UseCases.CalcularCustos;
using ImobiAPI.Application.UseCases.ConsultarMunicipio;
using ImobiAPI.Domain.Services;
using ImobiAPI.Infrastructure.Persistence;
using ImobiAPI.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();
builder.Services.AddScoped<ITabelaEmolumentosRepository, TabelaEmolumentosRepository>();

builder.Services.AddScoped<CalculadorCustosService>();

builder.Services.AddScoped<CalcularCustosUseCase>();
builder.Services.AddScoped<ConsultarMunicipioUseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();
app.MapControllers();

app.Run();