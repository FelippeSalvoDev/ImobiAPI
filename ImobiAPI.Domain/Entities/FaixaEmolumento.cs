using ImobiAPI.Domain.Enums;

namespace ImobiAPI.Domain.Entities;

public class FaixaEmolumento
{
    public int Id { get; private set; }
    public int TabelaEmolumentosId { get; private set; }
    public decimal ValorMinimo { get; private set; }
    public decimal? ValorMaximo { get; private set; }
    public decimal ValorFixo { get; private set; }
    public decimal? PercentualExcedente { get; private set; }
    public TipoAto TipoAto { get; private set; }

    protected FaixaEmolumento() { }

    public FaixaEmolumento(
        int tabelaEmolumentosId,
        decimal valorMinimo,
        decimal valorFixo,
        TipoAto tipoAto,
        decimal? valorMaximo = null,
        decimal? percentualExcedente = null)
    {
        if (valorMinimo < 0)
            throw new ArgumentException("Valor mínimo não pode ser negativo.");

        if (valorFixo < 0)
            throw new ArgumentException("Valor fixo não pode ser negativo.");

        TabelaEmolumentosId = tabelaEmolumentosId;
        ValorMinimo = valorMinimo;
        ValorMaximo = valorMaximo;
        ValorFixo = valorFixo;
        PercentualExcedente = percentualExcedente;
        TipoAto = tipoAto;
    }

    public decimal CalcularEmolumento(decimal valorImovel)
    {
        if (valorImovel < ValorMinimo)
            return 0;

        if (ValorMaximo.HasValue && valorImovel > ValorMaximo.Value)
            return 0;

        var base_ = ValorFixo;

        if (PercentualExcedente.HasValue)
            base_ += (valorImovel - ValorMinimo) * (PercentualExcedente.Value / 100);

        return Math.Round(base_, 2);
    }
}