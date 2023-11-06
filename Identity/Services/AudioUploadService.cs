using Core.Interfaces;

using Identity.Extensions;

using Zvukogram;

namespace Identity.Services;

internal sealed class AudioUploadService : IAudioUploadService
{
	private readonly HttpClient _client;
	private readonly IAudioService _audio;
	private readonly ZvukogramService _zvukogram;
	private readonly FileService _fileService;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="client">HTTP клиент.</param>
	/// <param name="audio">Сервис для работы с таблицей аудио.</param>
	/// <param name="zvukogram">Сервис для работы со Zvukogram.</param>
	public AudioUploadService(HttpClient client, IAudioService audio, ZvukogramService zvukogram, FileService fileService)
	{
		_client = client;
		_audio = audio;
		_zvukogram = zvukogram;
		_fileService = fileService;
	}

	/// <inheritdoc/>
	public async Task<Uri?> GetAudioAsync(int id)
	{
		var audio = await _audio.GetAudioAsync(id);

		if (audio is not null && await ExistAsync(audio))
		{
			return audio;
		}
		else
		{
			var uploadedAudio = await UploadTranslationAudio(id);

			if (uploadedAudio is not null)
			{
				await _audio.SetAudioAsync(id, uploadedAudio);

				return uploadedAudio;
			}
		}

		return null;
	}

	/// <inheritdoc/>
	public async Task<Uri?> UploadTranslationAudio(int translationId)
	{
		var speechSetting = await _audio.GetSpeechSettingAsync(translationId);

		var audioUrl = await _zvukogram.GetAudioAsync(speechSetting);

		return audioUrl is not null ? await UploadAsync(translationId, audioUrl) : null;
	}

	public async Task<Uri?> UploadAsync(int translationId, Uri url)
	{
		using var response = await _client.GetAsync(url);

		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var audioPath = await GetAudioSavePath(translationId);
		await SaveAudioAsync(response, audioPath.ToString());

		await _audio.SetAudioAsync(translationId, audioPath);

		return audioPath;
	}

	/// <inheritdoc/>
	public async Task<bool> ExistAsync(Uri? url)
	{
		using var response = await _client.GetAsync(url);
		return response.IsSuccessStatusCode;
	}

	/// <inheritdoc/>
	public Task<bool> UploadAsync(Uri url)
	{
		throw new NotImplementedException();
	}

	/// <inheritdoc/>
	public async Task<Uri> GetAudioSavePath(int translationId)
	{
		var audioPath = await _audio.GetAudioPathAsync(translationId);
		return new Uri(_fileService.GetFilePath(audioPath), UriKind.Relative);
	}

	private static async Task SaveAudioAsync(HttpResponseMessage response, string filePath)
	{
		// TODO: исправить, путь к папке со статичными файлами захардкоден.
		using var fileStream = new FileStream("wwwroot/" + filePath, FileMode.Create);
		await response.Content.CopyToAsync(fileStream);
	}
}
