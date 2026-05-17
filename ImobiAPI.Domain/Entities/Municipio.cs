using ImobiAPI.Domain.ValueObjects;

namespace ImobiAPI.Domain.Entities;

public class Municipio
{
    public int Id { get; private set; }
    public CodigoIBGE CodigoIBGE { get; private set; }
    public string Nome { get; private set; }
    public string UF { get; private set; }
    public int? Populacao { get; private set; }
    public bool Suportado { get; private set; }
    public DateTime AtualizadoEm { get; private set; }
    public AliquotaITBI? AliquotaITBI { get; private set; }

    protected Municipio()
    {
        CodigoIBGE = null!;
        Nome = null!;
        UF = null!;
    }

    public Municipio(string codigoIBGE, string nome, string uf, int? populacao = null)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do município não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(uf) || uf.Length != 2)
            throw new ArgumentException("UF deve ter exatamente 2 caracteres.");

        CodigoIBGE = new CodigoIBGE(codigoIBGE);
        Nome = nome;
        UF = uf.ToUpper();
        Populacao = populacao;
        Suportado = false;
        AtualizadoEm = DateTime.UtcNow;
    }

    public void DefinirAliquotaITBI(AliquotaITBI aliquota)
    {
        ArgumentNullException.ThrowIfNull(aliquota);
        AliquotaITBI = aliquota;
        Suportado = true;
        AtualizadoEm = DateTime.UtcNow;
    }
}