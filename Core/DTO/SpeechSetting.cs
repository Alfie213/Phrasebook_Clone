namespace Core.DTO;

/// <summary>
/// Содержит настройки для создания файла озвучивания.
/// </summary>
/// <param name="Text">Озвучиваемый текст.</param>
/// <param name="Voice">Голос озвучивания.</param>
public record struct SpeechSetting(string Text, string Voice);
