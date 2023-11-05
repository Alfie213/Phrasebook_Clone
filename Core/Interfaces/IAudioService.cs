using Core.DTO;

namespace Core.Interfaces;

/// <summary>
/// Сервис для работы с файлами озвучивания.
/// </summary>
public interface IAudioService
{
	/// <summary>
	/// Возвращает ссылку на файл озвучивания.
	/// </summary>
	/// <param name="translationId">ID файла озвучивания.</param>
	/// <returns>Ссылка на файл озвучивания.</returns>
	Task<Uri?> GetAudioAsync(int translationId);

	/// <summary>
	/// Задаёт ссылку на файл озвучивания.
	/// </summary>
	/// <param name="translationId">ID перевода.</param>
	/// <param name="audio">Ссылка на файл озвучивания на сервере.</param>
	Task SetAudioAsync(int translationId, Uri audio);

	/// <summary>
	/// Возвращает настройки для создания файла озвучивания.
	/// </summary>
	/// <param name="id">ID файла озвучивания.</param>
	/// <returns>Настройки для создания файла озвучивания.</returns>
	Task<SpeechSetting> GetSpeechSettingAsync(int id);

	/// <summary>
	/// Возвращает <see cref="AudioPath"/> для создания пути к файлу озвучивания.
	/// </summary>
	/// <param name="id">ID файла озвучивания.</param>
	/// <returns><see cref="AudioPath"/> для создания пути к файлу озвучивания.</returns>
	Task<AudioPath> GetAudioPathAsync(int id);
}
