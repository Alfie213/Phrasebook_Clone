using Core.Models;

using Phrasebook.DTO;

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
	Task<Response<UserModel>> GetUserModelAsync();
}
