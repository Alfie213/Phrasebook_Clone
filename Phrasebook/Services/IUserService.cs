using Core.Models;

namespace Phrasebook.Services;

/// <summary>
/// Сервис для работы с информацией о пользователе.
/// </summary>
public interface IUserService
{
	/// <summary>
	/// Возвращает информацию о пользователе.
	/// </summary>
	/// <returns>Возвращает информацию о пользователе.</returns>
	Task<UserModel> GetUserModelAsync();
}
