namespace Database.Entities;

/// <summary>
/// Представляет таблицу с категориями.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
[Comment("Категории.")]
public class Category
{
    /// <summary>
    /// ID категории.
    /// </summary>
    [Comment("ID категории.")]
    public int Id { get; set; }

    /// <summary>
    /// Название категории.
    /// </summary>
    [MaxLength(64)]
    [Comment("Название категории.")]
    public required string Name { get; set; }

    /// <summary>
    /// Порядок сортировки.
    /// </summary>
    [Comment("Порядок сортировки.")]
    public int Order { get; set; }

    /// <summary>
    /// Определяет, включена ли категория.
    /// </summary>
    [Comment("Определяет, включена ли категория.")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Фразы, которые входят в эту категорию.
    /// </summary>
    public ICollection<Phrase>? Phrases { get; }
}
