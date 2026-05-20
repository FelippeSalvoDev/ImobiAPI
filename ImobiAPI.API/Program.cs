using ImobiAPI.Application.Interfaces;
using ImobiAPI.Application.UseCases.CalcularCustos;
using ImobiAPI.Application.UseCases.ConsultarMunicipio;
using ImobiAPI.Domain.Services;
using ImobiAPI.Infrastructure.Persistence;
using ImobiAPI.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// repositórios
builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();
builder.Services.AddScoped<ITabelaEmolumentosRepository, TabelaEmolumentosRepository>();

// serviços de domínio
builder.Services.AddScoped<CalculadorCustosService>();

// use cases
builder.Services.AddScoped<CalcularCustosUseCase>();
builder.Services.AddScoped<ConsultarMunicipioUseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();