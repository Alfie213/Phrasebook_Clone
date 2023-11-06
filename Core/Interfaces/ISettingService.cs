namespace Core.Interfaces;

/// <summary>
/// Сервис для работы с настройками.
/// </summary>
public interface ISettingService
{
	/// <summary>
	/// Возвращает ID основного языка приложения.
	/// </summary>
	/// <returns>ID основного языка приложения.</returns>
	Task<int> GetOriginalLanguageId();

	/// <summary>
	/// Задаёт ID основного языка приложения.
	/// </summary>
	/// <param name="id">ID основного языка приложения.</param>
	Task SetOriginalLanguageId(int id);
}
