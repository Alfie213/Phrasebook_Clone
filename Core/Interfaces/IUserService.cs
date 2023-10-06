using Core.Models;

namespace Core.Interfaces;

/// <summary>
/// Сервис для работы с пользователями.
/// </summary>
public interface IUserService
{
	/// <summary>
	/// Возвращает информацию о пользователе.
	/// </summary>
	/// <param name="userId">ID пользователя.</param>
	/// <returns>Возвращает информацию о пользователе.</returns>
	Task<UserModel?> GetUserModelAsync(string userId);
}
