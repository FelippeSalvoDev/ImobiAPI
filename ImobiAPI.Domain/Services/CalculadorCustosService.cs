using ImobiAPI.Domain.Entities;
using ImobiAPI.Domain.Enums;

namespace ImobiAPI.Domain.Services;

public class ResultadoCalculo
{
    public decimal ValorImovel { get; init; }
    public decimal ValorITBI { get; init; }
    public decimal AliquotaITBI { get; init; }
    public decimal ValorEscritura { get; init; }
    public decimal ValorRegistro { get; init; }
    public decimal TotalCustos { get; init; }
    public decimal PercentualSobreImovel { get; init; }
    public bool Isento { get; init; }
}

public class CalculadorCustosService
{
    public ResultadoCalculo Calcular(
        Municipio municipio,
        decimal valorImovel,
        bool financiado,
        TabelaEmolumentos tabelaEscritura,
        TabelaEmolumentos tabelaRegistro)
    {
        ArgumentNullException.ThrowIfNull(municipio);
        ArgumentNullException.ThrowIfNull(tabelaEscritura);
        ArgumentNullException.ThrowIfNull(tabelaRegistro);

        if (valorImovel <= 0)
            throw new ArgumentException("Valor do imóvel deve ser maior que zero.");

        if (!municipio.Suportado || municipio.AliquotaITBI is null)
            throw new InvalidOperationException($"Município {municipio.Nome} não possui alíquota de ITBI cadastrada.");

        var aliquotaITBI = municipio.AliquotaITBI;

        var isento = aliquotaITBI.LimiteIsencao.HasValue &&
                     valorImovel <= aliquotaITBI.LimiteIsencao.Value;

        var valorITBI = isento
            ? 0
            : Math.Round(valorImovel * (aliquotaITBI.ObterAliquotaEfetiva(financiado) / 100), 2);

        var valorEscritura = tabelaEscritura.CalcularEmolumento(valorImovel);
        var valorRegistro = tabelaRegistro.CalcularEmolumento(valorImovel);

        var totalCustos = valorITBI + valorEscritura + valorRegistro;
        var percentual = Math.Round(totalCustos / valorImovel * 100, 2);

        return new ResultadoCalculo
        {
            ValorImovel = valorImovel,
            ValorITBI = valorITBI,
            AliquotaITBI = aliquotaITBI.ObterAliquotaEfetiva(financiado),
            ValorEscritura = valorEscritura,
            ValorRegistro = valorRegistro,
            TotalCustos = totalCustos,
            PercentualSobreImovel = percentual,
            Isento = isento
        };
    }
}