namespace ImobiAPI.Application.UseCases.AuthGoogle;

public record AuthGoogleResponse(
    string Token,
    string Email,
    string Nome,
    string? FotoPerfil,
    bool PrimeiroAcesso
);