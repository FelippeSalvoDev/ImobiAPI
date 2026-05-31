using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using ImobiAPI.Application.DTOs;
using ImobiAPI.Application.UseCases.CalcularCustos;
using Xunit;

namespace ImobiAPI.IntegrationTests.Controllers;

public class CalculoControllerTests : ApiTestBase
{
    [Fact]
    public async Task Calcular_DeveRetornar200_QuandoDadosValidos()
    {
        var request = new CalcularCustosRequest("3106200", 500000, false);

        var response = await Client.PostAsJsonAsync("/v1/calcular", request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Calcular_DeveRetornarEnvelopeCorreto_QuandoDadosValidos()
    {
        var request = new CalcularCustosRequest("3106200", 500000, false);

        var response = await Client.PostAsJsonAsync("/v1/calcular", request);
        var resultado = await response.Content.ReadFromJsonAsync<ApiResponse<CalcularCustosResponse>>();

        resultado!.Sucesso.Should().BeTrue();
        resultado.Dados.Should().NotBeNull();
        resultado.Erro.Should().BeNull();
    }

    [Fact]
    public async Task Calcular_DeveRetornarResultadoCorreto_QuandoBeloHorizonte()
    {
        var request = new CalcularCustosRequest("3106200", 500000, false);

        var response = await Client.PostAsJsonAsync("/v1/calcular", request);
        var resultado = await response.Content.ReadFromJsonAsync<ApiResponse<CalcularCustosResponse>>();

        resultado!.Dados!.Municipio.Should().Be("Belo Horizonte");
        resultado.Dados.ValorITBI.Should().Be(15000);
        resultado.Dados.TotalCustos.Should().Be(19300);
        resultado.Dados.FonteLegalITBI.Should().Be("Lei 5.839/1991");
    }

    [Fact]
    public async Task Calcular_DeveRetornar401_QuandoSemApiKey()
    {
        var clientSemKey = new HttpClient { BaseAddress = new Uri("http://localhost:5023") };
        var request = new CalcularCustosRequest("3106200", 500000, false);

        var response = await clientSemKey.PostAsJsonAsync("/v1/calcular", request);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Calcular_DeveRetornar404_QuandoMunicipioNaoEncontrado()
    {
        var request = new CalcularCustosRequest("9999999", 500000, false);

        var response = await Client.PostAsJsonAsync("/v1/calcular", request);
        var resultado = await response.Content.ReadFromJsonAsync<ApiResponse<CalcularCustosResponse>>();

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        resultado!.Sucesso.Should().BeFalse();
        resultado.Erro!.Codigo.Should().Be("IM001");
    }
}