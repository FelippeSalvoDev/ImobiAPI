using Google.Apis.Auth;
using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace ImobiAPI.Application.UseCases.AuthGoogle;

public class AuthGoogleUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IJwtService _jwtService;
    private readonly IConfiguration _configuration;

    public AuthGoogleUseCase(
        IUsuarioRepository usuarioRepository,
        IJwtService jwtService,
        IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _jwtService = jwtService;
        _configuration = configuration;
    }

    public async Task<AuthGoogleResponse> ExecutarAsync(AuthGoogleRequest request)
    {
        var clientId = _configuration["Google:ClientId"]!;

        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new[] { clientId }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);

        var usuario = await _usuarioRepository.ObterPorGoogleIdAsync(payload.Subject);
        var primeiroAcesso = usuario is null;

        if (usuario is null)
        {
            usuario = new Usuario(
                googleId: payload.Subject,
                email: payload.Email,
                nome: payload.Name,
                fotoPerfil: payload.Picture);

            await _usuarioRepository.AdicionarAsync(usuario);
        }

        var token = _jwtService.GerarToken(usuario);

        return new AuthGoogleResponse(
            Token: token,
            Email: usuario.Email,
            Nome: usuario.Nome,
            FotoPerfil: usuario.FotoPerfil,
            PrimeiroAcesso: primeiroAcesso);
    }
}