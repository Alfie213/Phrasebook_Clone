using Phrasebook.DTO;

namespace Phrasebook.Services;

/// <summary>
/// Сервис для регистрации пользователей.
/// </summary>
public interface IRegistrationService
{
	/// <summary>
	/// Регистрирует пользователя.
	/// </summary>
	/// <param name="email">Почта.</param>
	/// <param name="password">Пароль.</param>
	Task<Response> SignUp(string email, string password);
}
