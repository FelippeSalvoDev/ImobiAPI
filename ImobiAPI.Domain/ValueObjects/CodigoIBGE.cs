namespace ImobiAPI.Domain.ValueObjects;

public record CodigoIBGE
{
    public string Valor { get; }

    public CodigoIBGE(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("Código IBGE não pode ser vazio.");

        if (valor.Length != 7 || !valor.All(char.IsDigit))
            throw new ArgumentException("Código IBGE deve conter exatamente 7 dígitos.");

        Valor = valor;
    }

    public override string ToString() => Valor;
}