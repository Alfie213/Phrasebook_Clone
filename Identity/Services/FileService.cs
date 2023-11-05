using Core.DTO;

namespace Identity.Services;

/// <summary>
/// Вспомогательный класс для работы с папками и файлами для озвучивания.
/// </summary>
public class FileService
{
	private readonly IConfiguration _configuration = null!;

	/// <summary>
	/// Получает необходимые зависимости для правильной работы <see cref="FileService"/>.
	/// </summary>
	/// <param name="configuration">Конфигурация приложения.</param>
	public FileService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	/// <summary>
	/// Формирует путь к файлу озвучивания.
	/// </summary>
	/// <param name="audioPath">Данные для формирования пути.</param>
	/// <returns>Путь к файлу озвучивания.</returns>
	public string GetFilePath(AudioPath audioPath)
	{
		var fileName = GetName(audioPath.Text);
		var fileFolder = CreateDirectory(audioPath.Language, audioPath.Voice);
		return Path.Combine(fileFolder, fileName);
	}

	/// <summary>
	/// Формирует путь к папке для хранения файла озвучивания
	/// и создаёт её, если она ещё не была создана.
	/// </summary>
	/// <param name="language">Название языка.</param>
	/// <param name="voice">Название голоса.</param>
	/// <returns>Путь к папке для хранения файла озвучивания.</returns>
	public string CreateDirectory(string language, string voice)
	{
		var fileFolder = Path.Combine(GetAudioFolder(), language, voice);
		Directory.CreateDirectory("wwwroot/" + fileFolder);

		return fileFolder;
	}

	/// <summary>
	/// Формирует название файла озвучивания для хранения на сервере.
	/// </summary>
	/// <param name="phrase">Озвучиваемая фраза.</param>
	/// <returns>Название файла озвучивания для хранения на сервере.</returns>
	public static string GetName(string phrase)
	{
		var format = "mp3";

		return Path.ChangeExtension(phrase, format);
	}

	private string GetAudioFolder()
	{
		var audioFolder = _configuration.GetValue<string>("AudioFolder")
			?? throw new KeyNotFoundException();

		return audioFolder;
	}
}
