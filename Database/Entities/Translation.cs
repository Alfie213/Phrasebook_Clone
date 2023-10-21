namespace Database.Entities;

/// <summary>
/// Представляет таблицу с переводами.
/// </summary>
[Comment("Переводы.")]
public sealed class Translation
{
	/// <summary>
	/// ID перевода.
	/// </summary>
	[Comment("ID перевода.")]
	public int Id { get; set; }

	/// <summary>
	/// ID переведённой фразы.
	/// </summary>
	[Comment("ID переведённой фразы.")]
	public int PhraseId { get; set; }

	/// <summary>
	/// ID языка, на котором осуществлён перевод.
	/// </summary>
	[Comment("ID языка, на котором осуществлён перевод.")]
	public int LanguageId { get; set; }

	/// <summary>
	/// Текст перевода.
	/// </summary>
	[MaxLength(128)]
	[Comment("Текст перевода.")]
	public required string Text { get; set; }

	/// <summary>
	/// Переведённая фраза.
	/// </summary>
	public Phrase? Phrase { get; }

	/// <summary>
	/// Язык, на котором осуществлён перевод.
	/// </summary>
	public Language? Language { get; }

	/// <summary>
	/// Аудиофайл с переводом.
	/// </summary>
	public Audio? Audio { get; }
}
