using Microsoft.Extensions.Primitives;
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
	public JwtSecurityToken CreateToken(string userId)
	{
		var claims = new Claim[]
		{
			new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new (JwtRegisteredClaimNames.Sub, userId)
		};

		return new JwtSecurityToken(
			issuer: _options.Issuer,
			audience: _options.Audience,
			expires: DateTime.Now.AddHours(1),
			claims: claims,
			signingCredentials: new SigningCredentials(_options.Key, SecurityAlgorithms.HmacSha256));
	}

	public static string GetTokenFromAuthorizationHeader(StringValues authorization)
	{
		const string bearerPrefix = "Bearer ";

		var value = authorization.First(header => header is not null
			&& header.StartsWith(bearerPrefix, StringComparison.InvariantCultureIgnoreCase))!;

		return value[bearerPrefix.Length..];
	}

	/// <summary>
	/// Возвращает ID пользователя.
	/// </summary>
	/// <param name="token">Токен</param>
	/// <returns>ID пользователя.</returns>
	public string GetUserId(string token)
	{
		var jwtSecurityToken = _tokenHandler.ReadJwtToken(token);
		return jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
	}
}
