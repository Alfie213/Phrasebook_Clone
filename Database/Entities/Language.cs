namespace Database.Entities;

/// <summary>
/// Представляет таблицу с языками для изучения.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
[Comment("Языки для изучения.")]
public sealed class Language
{
    /// <summary>
    /// ID языка.
    /// </summary>
    [Comment("ID языка.")]
    public int Id { get; set; }

    /// <summary>
    /// Название языка.
    /// </summary>
    [MaxLength(32)]
    [Comment("Название языка.")]
    public required string Name { get; set; }

    /// <summary>
    /// Порядок сортировки.
    /// </summary>
    [Comment("Порядок сортировки.")]
    public int Order { get; set; }

    /// <summary>
    /// Определяет, доступен ли язык.
    /// </summary>
    [Comment("Определяет, доступен ли язык.")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Переводы, выполненные на этом языке.
    /// </summary>
    public ICollection<Translation>? Translations { get; set; }

    /// <summary>
    /// Голоса, говорящие на этом языке.
    /// </summary>
    public ICollection<Voice>? Voices { get; set; }
}
