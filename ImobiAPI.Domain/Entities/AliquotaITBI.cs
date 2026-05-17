namespace ImobiAPI.Domain.Entities;

public class AliquotaITBI
{
    public int Id { get; private set; }
    public int MunicipioId { get; private set; }
    public decimal Aliquota { get; private set; }
    public decimal? AliquotaFinanciado { get; private set; }
    public decimal? LimiteIsencao { get; private set; }
    public string FonteLegal { get; private set; }
    public int AnoVigencia { get; private set; }
    public bool Ativo { get; private set; }

    protected AliquotaITBI() { }

    public AliquotaITBI(
        int municipioId,
        decimal aliquota,
        int anoVigencia,
        string fonteLegal,
        decimal? aliquotaFinanciado = null,
        decimal? limiteIsencao = null)
    {
        if (aliquota <= 0 || aliquota > 100)
            throw new ArgumentException("Alíquota deve ser entre 0 e 100.");

        MunicipioId = municipioId;
        Aliquota = aliquota;
        AnoVigencia = anoVigencia;
        FonteLegal = fonteLegal;
        AliquotaFinanciado = aliquotaFinanciado;
        LimiteIsencao = limiteIsencao;
        Ativo = true;
    }

    public decimal ObterAliquotaEfetiva(bool financiado) =>
        financiado && AliquotaFinanciado.HasValue ? AliquotaFinanciado.Value : Aliquota;
}