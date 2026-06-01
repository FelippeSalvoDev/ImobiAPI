using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ImobiAPI.Application.Interfaces;
using ImobiAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ImobiAPI.Infrastructure.Auth;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GerarToken(Usuario usuario)
    {
        var chave = _configuration["Jwt:Chave"]!;
        var emissor = _configuration["Jwt:Emissor"]!;
        var audiencia = _configuration["Jwt:Audiencia"]!;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chave));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Name, usuario.Nome)
        };

        var token = new JwtSecurityToken(
            issuer: emissor,
            audience: audiencia,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public int? ObterUsuarioId(string token)
    {
        try
        {
            var chave = _configuration["Jwt:Chave"]!;
            var handler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chave));

            handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out var validatedToken);

            var jwt = (JwtSecurityToken)validatedToken;
            var id = jwt.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return int.Parse(id);
        }
        catch
        {
            return null;
        }
    }
}