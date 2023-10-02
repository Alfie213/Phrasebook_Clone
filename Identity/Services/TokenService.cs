using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identity.Services;

/// <summary>
/// Сервис для работы с JWT токеном.
/// </summary>
public sealed class TokenService
{
    private readonly JwtSecurityTokenHandler _tokenHandler = new();
    private readonly JwtOptions _options;

    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="options">Настройки для</param>
    public TokenService(JwtOptions options)
    {
        _options = options;
    }

    /// <summary>
    /// Создаёт токен.
    /// </summary>
    /// <param name="claims"></param>
    /// <returns>Токен.</returns>
    public JwtSecurityToken CreateToken(IEnumerable<Claim> claims)
    {
        return new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            expires: DateTime.Now.AddHours(1),
            claims: claims,
            signingCredentials: new SigningCredentials(_options.Key, SecurityAlgorithms.HmacSha256));
    }

    /// <summary>
    /// Возвращает список из <see cref="Claim"/>, связанных с <paramref name="token"/>.
    /// </summary>
    /// <param name="token">Токен.</param>
    /// <returns>Список из <see cref="Claim"/>, связанных с <paramref name="token"/>.</returns>
    public IEnumerable<Claim> ReadToken(string token)
    {
        var jwtSecurityToken = _tokenHandler.ReadJwtToken(token);
        return jwtSecurityToken.Claims;
    }

    /// <summary>
    /// Проверяет, является ли токен действительным.
    /// </summary>
    /// <param name="token">Токен</param>
    /// <returns><see langword="true"/>, если токен действителен, иначе - <see langword="false"/>.</returns>
    public async Task<bool> IsTokenValidAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return false;
        }

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = _options.Key,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = _options.Issuer,
            ValidAudience = _options.Audience,
            RequireExpirationTime = true,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var validationResult = await tokenHandler.ValidateTokenAsync(token, validationParameters);

        return validationResult.IsValid;
    }
}
