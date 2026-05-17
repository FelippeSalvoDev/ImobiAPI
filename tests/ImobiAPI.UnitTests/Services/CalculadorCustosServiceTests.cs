using FluentAssertions;
using ImobiAPI.Domain.Entities;
using ImobiAPI.Domain.Enums;
using ImobiAPI.Domain.Services;

namespace ImobiAPI.UnitTests.Services;

public class CalculadorCustosServiceTests
{
    private readonly CalculadorCustosService _service = new();

    private static Municipio CriarMunicipioComAliquota(
        decimal aliquota,
        decimal? aliquotaFinanciado = null,
        decimal? limiteIsencao = null)
    {
        var municipio = new Municipio("3106200", "Belo Horizonte", "MG");

        var aliquotaITBI = new AliquotaITBI(
            municipioId: 1,
            aliquota: aliquota,
            anoVigencia: 2024,
            fonteLegal: "Lei 11.253/2024",
            aliquotaFinanciado: aliquotaFinanciado,
            limiteIsencao: limiteIsencao);

        municipio.DefinirAliquotaITBI(aliquotaITBI);
        return municipio;
    }

    private static TabelaEmolumentos CriarTabelaSimples(TipoAto tipoAto, decimal valorFixo)
    {
        var tabela = new TabelaEmolumentos("MG", 2024, tipoAto, "TJ-MG");

        var faixa = new FaixaEmolumento(
            tabelaEmolumentosId: 1,
            valorMinimo: 0,
            valorFixo: valorFixo,
            tipoAto: tipoAto);

        tabela.AdicionarFaixa(faixa);
        return tabela;
    }

    [Fact]
    public void Calcular_DeveRetornarITBICorreto_QuandoImovelNaoFinanciado()
    {
        var municipio = CriarMunicipioComAliquota(aliquota: 3);
        var escritura = CriarTabelaSimples(TipoAto.Escritura, 5000);
        var registro = CriarTabelaSimples(TipoAto.Registro, 3000);

        var resultado = _service.Calcular(municipio, 500000, false, escritura, registro);

        resultado.ValorITBI.Should().Be(15000);
        resultado.AliquotaITBI.Should().Be(3);
    }

    [Fact]
    public void Calcular_DeveUsarAliquotaFinanciado_QuandoImovelFinanciado()
    {
        var municipio = CriarMunicipioComAliquota(aliquota: 3, aliquotaFinanciado: 1.5m);
        var escritura = CriarTabelaSimples(TipoAto.Escritura, 5000);
        var registro = CriarTabelaSimples(TipoAto.Registro, 3000);

        var resultado = _service.Calcular(municipio, 500000, true, escritura, registro);

        resultado.ValorITBI.Should().Be(7500);
        resultado.AliquotaITBI.Should().Be(1.5m);
    }

    [Fact]
    public void Calcular_DeveRetornarITBIZero_QuandoImovelDentroDoLimiteDeIsencao()
    {
        var municipio = CriarMunicipioComAliquota(aliquota: 3, limiteIsencao: 200000);
        var escritura = CriarTabelaSimples(TipoAto.Escritura, 5000);
        var registro = CriarTabelaSimples(TipoAto.Registro, 3000);

        var resultado = _service.Calcular(municipio, 150000, false, escritura, registro);

        resultado.ValorITBI.Should().Be(0);
        resultado.Isento.Should().BeTrue();
    }

    [Fact]
    public void Calcular_DeveRetornarTotalCorreto_SomandoTodosOsCustos()
    {
        var municipio = CriarMunicipioComAliquota(aliquota: 3);
        var escritura = CriarTabelaSimples(TipoAto.Escritura, 5000);
        var registro = CriarTabelaSimples(TipoAto.Registro, 3000);

        var resultado = _service.Calcular(municipio, 500000, false, escritura, registro);

        resultado.TotalCustos.Should().Be(23000); // 15000 + 5000 + 3000
        resultado.PercentualSobreImovel.Should().Be(4.6m);
    }

    [Fact]
    public void Calcular_DeveLancarExcecao_QuandoValorImovelZero()
    {
        var municipio = CriarMunicipioComAliquota(aliquota: 3);
        var escritura = CriarTabelaSimples(TipoAto.Escritura, 5000);
        var registro = CriarTabelaSimples(TipoAto.Registro, 3000);

        var act = () => _service.Calcular(municipio, 0, false, escritura, registro);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Valor do imóvel deve ser maior que zero.");
    }

    [Fact]
    public void Calcular_DeveLancarExcecao_QuandoMunicipioSemAliquota()
    {
        var municipio = new Municipio("3106200", "Belo Horizonte", "MG");
        var escritura = CriarTabelaSimples(TipoAto.Escritura, 5000);
        var registro = CriarTabelaSimples(TipoAto.Registro, 3000);

        var act = () => _service.Calcular(municipio, 500000, false, escritura, registro);

        act.Should().Throw<InvalidOperationException>();
    }
}