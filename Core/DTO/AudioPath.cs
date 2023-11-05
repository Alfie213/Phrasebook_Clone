namespace Core.DTO;

/// <summary>
/// Класс с данными для создания пути к файлу озвучивания.
/// </summary>
/// <param name="Language">Название языка.</param>
/// <param name="Voice">Голос озвучивания.</param>
/// <param name="Text">Озвучиваемый текст.</param>
public record struct AudioPath(string Language, string Voice, string Text);
