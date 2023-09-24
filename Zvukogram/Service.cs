using Microsoft.Extensions.Configuration;

using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;

using Zvukogram.Request;

namespace Zvukogram;

/// <summary>
/// Сервис для работы с API Звукограма.
/// </summary>
public class Service
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;
    private readonly Uri _api;

    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="client">HTTP клиент.</param>
    /// <param name="configuration">Конфигурация.</param>
    /// <exception cref="KeyNotFoundException">
    /// Выбрасывается, если не удалось получить ссылку на API в <paramref name="configuration"/>.
    /// </exception>
    public Service(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _configuration = configuration;

        _api = configuration.GetValue<Uri>("Api")
            ?? throw new KeyNotFoundException("Api");
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
        var body = new Body(_configuration, parameters).Serialize();

        using var content = CreateContent(body);
        using var response = await _client.PostAsync(_api, content);

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
