namespace Database.Entities;

/// <summary>
/// Представляет таблицу с фразами.
/// </summary>
[Index(nameof(Text), IsUnique = true)]
[Comment("Фразы.")]
public sealed class Phrase
{
    /// <summary>
    /// ID фразы.
    /// </summary>
    [Comment("ID фразы.")]
    public int Id { get; set; }

    /// <summary>
    /// ID категории, к которой относится эта фраза.
    /// </summary>
    [Comment("ID категории, к которой относится эта фраза.")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Текст фразы.
    /// </summary>
    [MaxLength(128)]
    [Comment("Текст фразы.")]
    public required string Text { get; set; }

    /// <summary>
    /// Порядок сортировки.
    /// </summary>
    [Comment("Порядок сортировки.")]
    public int Order { get; set; }

    /// <summary>
    /// Определяет, включена ли фраза.
    /// </summary>
    [Comment("Определяет, включена ли фраза.")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Категория, к которой относится эта фраза.
    /// </summary>
    public Category? Category { get; set; }
}
