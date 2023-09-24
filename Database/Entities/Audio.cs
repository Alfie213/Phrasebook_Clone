using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities;

/// <summary>
/// Представляет таблицу с аудиофайлами.
/// </summary>
[Index(nameof(Source), IsUnique = true)]
[Comment("Аудиофайлы.")]
public class Audio
{
    /// <summary>
    /// ID аудиофайла.
    /// </summary>
    [ForeignKey(nameof(Translation))]
    [Comment("ID аудиофайла.")]
    public int Id { get; set; }

    /// <summary>
    /// ID голоса, который озвучил этот аудиофайл.
    /// </summary>
    [Comment("ID голоса, который озвучил этот аудиофайл.")]
    public int VoiceId { get; set; }

    /// <summary>
    /// Ссылка на аудиофайл.
    /// </summary>
    [MaxLength(256)]
    [Comment("Ссылка на аудиофайл.")]
    public Uri? Source { get; set; }

    /// <summary>
    /// Перевод, для которого предназначен этот аудиофайл.
    /// </summary>
    public Translation? Translation { get; }

    /// <summary>
    /// Голос, который озвучил этот аудиофайл.
    /// </summary>
    public Voice? Voice { get; }
}
