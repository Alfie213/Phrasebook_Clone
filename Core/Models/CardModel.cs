namespace Core.Models;

/// <summary>
/// Модель карточки для обучения.
/// </summary>
public sealed class CardModel
{
    /// <summary>
    /// Оригинальная фраза.
    /// </summary>
    public required PhraseModel Phrase { get; init; }

    /// <summary>
    /// Переведённая фраза.
    /// </summary>
    public required PhraseModel Translate { get; init; }
}
