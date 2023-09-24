namespace Zvukogram.Request;

/// <summary>
/// Параметры запроса.
/// </summary>
public sealed class Parameters
{
    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="text">Текст, который необходимо озвучить.</param>
    /// <param name="voice">Голос, которым будет озвучен <paramref name="text"/>.</param>
    public Parameters(string text, string voice)
    {
        Text = text;
        Voice = voice;
    }

    /// <inheritdoc cref="Body.Text"/>
    public string Text { get; }

    /// <inheritdoc cref="Body.Voice"/>
    public string Voice { get; }

    /// <inheritdoc cref="Request.Format"/>
    public Format Format { get; set; }

    /// <inheritdoc cref="Body.Speed"/>
    public float Speed { get; set; } = Body.DefaultSpeed;

    /// <inheritdoc cref="Body.Pitch"/>
    public float Pitch { get; set; }

    /// <inheritdoc cref="Request.Emotion"/>
    public Emotion Emotion { get; set; }
}
