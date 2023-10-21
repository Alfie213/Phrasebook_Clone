namespace Database.Entities;

/// <summary>
/// Представляет таблицу с настройками.
/// </summary>
[Comment("Представляет таблицу с настройками.")]
public sealed class Setting
{
	/// <summary>
	/// Ключ.
	/// </summary>
	[Key]
	[MaxLength(128)]
	[Comment("Ключ.")]
	public required string Key { get; set; }

	/// <summary>
	/// Значение.
	/// </summary>
	[MaxLength(32)]
	[Comment("Значение.")]
	public required string Value { get; set; }
}
