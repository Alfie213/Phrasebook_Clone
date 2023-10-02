using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace Identity;

/// <summary>
/// Параметры для создания JWT токена.
/// </summary>
public class JwtOptions
{
    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="configuration">Конфигурация.</param>
    public JwtOptions(IConfiguration configuration)
    {
        Issuer = GetConfigurationKey(configuration, "Jwt:Issuer");
        Audience = GetConfigurationKey(configuration, "Jwt:Audience");

        var key = GetConfigurationKey(configuration, "Jwt:Key");
        Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }

    /// <summary>
    /// Источник, создавший токен.
    /// </summary>
    public string Issuer { get; }

    /// <summary>
    /// Получатель, для которого предназначен токен.
    /// </summary>
    public string Audience { get; }

    /// <summary>
    /// Ключ для шифрования и подписи.
    /// </summary>
    public SymmetricSecurityKey Key { get; }

    private static string GetConfigurationKey(IConfiguration configuration, string key)
    {
        return configuration[key] ?? throw new KeyNotFoundException(key);
    }
}
