using Core.Models;

namespace Core.Interfaces;

/// <summary>
/// Сервис для работы с <see cref="LearnModel"/>.
/// </summary>
public interface ICardModelService
{
	/// <summary>
	/// Возвращает <see cref="IAsyncEnumerable{LearnModel}"/> для отображения на странице изучения языка.
	/// </summary>
	/// <param name="languageId">ID языка.</param>
	/// <returns><see cref="IAsyncEnumerable{LearnModel}"/> для отображения на странице изучения языка.</returns>
	Task<IEnumerable<CardModel>> GetCardModelsAsync(int languageId);
}
