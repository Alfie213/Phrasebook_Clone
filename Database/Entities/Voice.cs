using Database.Enums;

namespace Database.Entities;

/// <summary>
/// Представляет таблицу с голосами.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
[Comment("Голоса.")]
public sealed class Voice
{
    /// <summary>
    /// ID голоса.
    /// </summary>
    [Comment("ID голоса..")]
    public int Id { get; set; }

    /// <summary>
    /// ID языка, на котором говорит этот голос.
    /// </summary>
    [Comment("ID языка, на котором говорит этот голос.")]
    public int LanguageId { get; set; }

    /// <summary>
    /// Название языка.
    /// </summary>
    [MaxLength(32)]
    [Comment("Название языка.")]
    public required string Name { get; set; }

    /// <summary>
    /// Пол языка.
    /// </summary>
    [Comment("Пол языка.")]
    public Gender Gender { get; set; }

    /// <summary>
    /// Язык, на котором говорит этот голос.
    /// </summary>
    public Language? Language { get; set; }

    /// <summary>
    /// Аудиофайлы, озвученные этим голосом.
    /// </summary>
    public ICollection<Audio>? Audios { get; }
}
