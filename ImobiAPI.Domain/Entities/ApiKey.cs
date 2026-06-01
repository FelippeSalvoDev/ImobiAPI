using ImobiAPI.Domain.Constants;

namespace ImobiAPI.Domain.Entities;

public class ApiKey
{
    public int Id { get; private set; }
    public string Chave { get; private set; }
    public string Email { get; private set; }
    public int? UsuarioId { get; private set; }
    public string Plano { get; private set; }
    public int LimiteDiario { get; private set; }
    public bool Ativa { get; private set; }
    public DateTime CriadoEm { get; private set; }

    protected ApiKey()
    {
        Chave = null!;
        Email = null!;
        Plano = null!;
    }

    public ApiKey(string email, string plano)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email não pode ser vazio.");

        if (plano != Planos.Gratuito && plano != Planos.Pro)
            throw new ArgumentException($"Plano '{plano}' inválido. Use '{Planos.Gratuito}' ou '{Planos.Pro}'.");

        Email = email;
        Plano = plano;
        Chave = GerarChave();
        LimiteDiario = DefinirLimitePorPlano(plano);
        Ativa = true;
        CriadoEm = DateTime.UtcNow;
    }

    public bool PodeRealizarChamada(int totalHoje) => Ativa && totalHoje < LimiteDiario;

    private static string GerarChave() =>
        $"imb_{Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=", "").Replace("+", "").Replace("/", "")}";

    private static int DefinirLimitePorPlano(string plano) => plano switch
    {
        Planos.Gratuito => 200,
        Planos.Pro => 10000,
        _ => throw new ArgumentException($"Plano '{plano}' inválido.")
    };
}