namespace Core.Models;

/// <summary>
/// Модель для описания фразы и её файла озвучивания.
/// </summary>
public sealed class PhraseModel
{
	/// <summary>
	/// ID перевода.
	/// </summary>
	public required int TranslationId { get; init; }

	/// <summary>
	/// Текст фразы.
	/// </summary>
	public required string Text { get; init; }

	/// <summary>
	/// Файл озвучивания.
	/// </summary>
	public Uri? Audio { get; set; }
}
