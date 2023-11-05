namespace Identity.Services;

/// <summary>
/// Сервис для загрузки файлов озвучивания.
/// </summary>
public interface IAudioUploadService
{
	/// <summary>
	/// Возвращает ссылку на загруженный файл озвучивания.
	/// </summary>
	/// <param name="id">ID файла озвучивания.</param>
	/// <returns>Ссылка на загруженный файл озвучивания.</returns>
	Task<Uri?> GetAudioAsync(int id);

	/// <summary>
	/// Загружает файл озвучивания на сервер.
	/// </summary>
	/// <param name="url">Ссылка, по которой нужно загрузить файл.</param>
	/// <returns>
	/// <see langword="true"/>, если файл озвучивания удалось загрузить, иначе - <see langword="false"/>
	/// </returns>
	Task<bool> UploadAsync(Uri url);

	/// <summary>
	/// Загружает файл озвучивания для перевода.
	/// </summary>
	/// <param name="id">ID перевода.</param>
	/// <returns>
	/// Возвращает <see cref="Uri"/>, если файл удалось загрузить, иначе - <see langword="null"/>.
	/// </returns>
	Task<Uri?> UploadTranslationAudio(int id);

	/// <summary>
	/// Проверяет, существует ли файл.
	/// </summary>
	/// <param name="url">Ссылка на файл.</param>
	/// <returns>
	/// <see langword="true"/>, если файл озвучивания существует на сервере, иначе - <see langword="false"/>
	/// </returns>
	Task<bool> ExistAsync(Uri? url);

	/// <summary>
	/// Формирует путь, по которому нужно сохранить файл озвучивания.
	/// </summary>
	/// <param name="translationId">ID перевода.</param>
	/// <returns>Путь, по которому нужно сохранить файл озвучивания.</returns>
	Task<Uri> GetAudioSavePath(int translationId);
}
