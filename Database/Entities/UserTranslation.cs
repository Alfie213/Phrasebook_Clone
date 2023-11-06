using Microsoft.AspNetCore.Identity;

namespace Database.Entities;

/// <summary>
/// Таблица, описывающая взаимодействие пользователя с переводами.
/// </summary>
[Index(nameof(UserId), nameof(TranslationId), IsUnique = true)]
[Comment("Взаимодействие пользователя с переводами.")]
public sealed class UserTranslation
{
	/// <summary>
	/// ID взаимодействия.
	/// </summary>
	[Comment("ID взаимодействия.")]
	public int Id { get; set; }

	/// <summary>
	/// ID пользователя.
	/// </summary>
	[Comment("ID пользователя.")]
	public required string UserId { get; set; }

	/// <summary>
	/// ID перевода, с которым взаимодействует пользователь.
	/// </summary>
	[Comment("ID перевода, с которым взаимодействует пользователь.")]
	public int TranslationId { get; set; }

	/// <summary>
	/// Определяет, выучил ли пользователь переведённую фразу.
	/// </summary>
	[Comment("Определяет, выучил ли пользователь переведённую фразу.")]
	public bool Learned { get; set; }

	/// <summary>
	/// Определяет, скрыл ли пользователь переведённую фразу.
	/// </summary>
	[Comment("Определяет, скрыл ли пользователь переведённую фразу.")]
	public bool Hidden { get; set; }

	/// <summary>
	/// Пользователь.
	/// </summary>
	public IdentityUser? User { get; }

	/// <summary>
	/// Перевод, с которым взаимодействует пользователь.
	/// </summary>
	public Translation? Translation { get; }
}
