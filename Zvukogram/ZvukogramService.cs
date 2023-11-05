using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;

using Zvukogram.Request;

namespace Zvukogram;

/// <summary>
/// Сервис для работы с API Звукограма.
/// </summary>
public class ZvukogramService
{
	private readonly HttpClient _client;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="client">HTTP клиент.</param>
	public ZvukogramService(HttpClient client)
	{
		_client = client;
	}

	/// <summary>
	/// Возвращает ссылку на аудиофайл.
	/// </summary>
	/// <param name="parameters">Параметры запроса.</param>
	/// <returns>
	/// Возвращает ссылку на аудиофайл или <see langword="null"/>, если в теле ответа ссылка пустая.
	/// </returns>
	public async Task<Uri?> GetAudioAsync(Parameters parameters)
	{
		var response = await SendRequestAsync(parameters);
		return response is not null ? GetAudio(response) : null;
	}

	internal virtual async Task<string> SendRequestAsync(Parameters parameters)
	{
		var body = new Body(parameters).Serialize();

		using var content = CreateContent(body);
		using var response = await _client.PostAsync(new Uri("https://zvukogram.com/index.php?r=api/text"), content);

		return await response.Content.ReadAsStringAsync();
	}

	private static StringContent CreateContent(string body)
	{
		var mediaType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);
		return new StringContent(body, mediaType);
	}

	private static Uri? GetAudio(string response)
	{
		var file = GetFileProperty(response);
		return !string.IsNullOrEmpty(file) ? new Uri(file) : null;
	}

	private static string? GetFileProperty(string response)
	{
		using var document = JsonDocument.Parse(response);
		return document.RootElement.GetProperty("file").GetString();
	}
}
