using Phrasebook.DTO;

namespace Phrasebook.Services;

/// <summary>
/// Сервис для работы с авторизацией пользователя.
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Авторизует пользователя в системе.
    /// </summary>
    /// <param name="email">Почта.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Возвращает токен для использования в дальнейших запросах.</returns>
    Task<Response<string>> AuthenticateAsync(string email, string password);
}
