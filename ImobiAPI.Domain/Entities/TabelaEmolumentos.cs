using ImobiAPI.Domain.Enums;

namespace ImobiAPI.Domain.Entities;

public class TabelaEmolumentos
{
    public int Id { get; private set; }
    public string UF { get; private set; }
    public int AnoVigencia { get; private set; }
    public TipoAto TipoAto { get; private set; }
    public string FonteTJ { get; private set; }
    public bool Ativo { get; private set; }
    public IReadOnlyCollection<FaixaEmolumento> Faixas => _faixas.AsReadOnly();

    private readonly List<FaixaEmolumento> _faixas = new();

    protected TabelaEmolumentos() { }

    public TabelaEmolumentos(string uf, int anoVigencia, TipoAto tipoAto, string fonteTJ)
    {
        if (string.IsNullOrWhiteSpace(uf) || uf.Length != 2)
            throw new ArgumentException("UF deve ter exatamente 2 caracteres.");

        UF = uf.ToUpper();
        AnoVigencia = anoVigencia;
        TipoAto = tipoAto;
        FonteTJ = fonteTJ;
        Ativo = true;
    }

    public void AdicionarFaixa(FaixaEmolumento faixa)
    {
        ArgumentNullException.ThrowIfNull(faixa);
        _faixas.Add(faixa);
    }

    public decimal CalcularEmolumento(decimal valorImovel)
    {
        var faixa = _faixas
            .FirstOrDefault(f =>
                valorImovel >= f.ValorMinimo &&
                (!f.ValorMaximo.HasValue || valorImovel <= f.ValorMaximo.Value));

        return faixa?.CalcularEmolumento(valorImovel) ?? 0;
    }
}