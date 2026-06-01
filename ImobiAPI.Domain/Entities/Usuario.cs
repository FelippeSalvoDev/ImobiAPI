namespace ImobiAPI.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }
    public string GoogleId { get; private set; }
    public string Email { get; private set; }
    public string Nome { get; private set; }
    public string? FotoPerfil { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public IReadOnlyCollection<ApiKey> ApiKeys => _apiKeys.AsReadOnly();

    private readonly List<ApiKey> _apiKeys = new();

    protected Usuario()
    {
        GoogleId = null!;
        Email = null!;
        Nome = null!;
    }

    public Usuario(string googleId, string email, string nome, string? fotoPerfil = null)
    {
        if (string.IsNullOrWhiteSpace(googleId))
            throw new ArgumentException("GoogleId não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio.");

        GoogleId = googleId;
        Email = email;
        Nome = nome;
        FotoPerfil = fotoPerfil;
        CriadoEm = DateTime.UtcNow;
    }

    public ApiKey CriarApiKey(string plano)
    {
        var apiKey = new ApiKey(Email, plano);
        _apiKeys.Add(apiKey);
        return apiKey;
    }
}