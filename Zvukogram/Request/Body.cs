using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using System.ComponentModel;

using Zvukogram.Json;

namespace Zvukogram.Request;

/// <summary>
/// Тело запроса к API Звукограма.
/// </summary>
[Serializable]
public sealed class Body
{
    private const float DefaultSpeed = 1;

    private readonly static JsonSerializerSettings s_settings = new()
    {
        DefaultValueHandling = DefaultValueHandling.Ignore,
        Converters = new[] { new FloatConverter() },
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };

    private float _speed = DefaultSpeed;
    private float _pitch;

    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="configuration">Конфигурация.</param>
    public Body(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

        Token = GetConfigurationValue(configuration, "Token");
        Email = GetConfigurationValue(configuration, "Email");
    }

    /// <summary>
    /// Секретный ключ для доступа к API, связанный с <see cref="Email"/>.
    /// </summary>
    public string Token { get; }

    /// <summary>
    /// Почта, зарегистрированная на сайте Звукограма
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// Название голоса, которым будет озвучен <see cref="Text"/>.
    /// </summary>
    public required string Voice { get; set; }

    /// <summary>
    /// Текст, который необходимо озвучить.
    /// </summary>
    public required string Text { get; set; }

    /// <inheritdoc cref="Format"/>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public Format Format { get; set; }

    /// <summary>
    /// Скорость произношения.
    /// </summary>
    [DefaultValue(DefaultSpeed)]
    public float Speed
    {
        get => _speed;
        set => _speed = Math.Clamp(value, 0.1f, 2);
    }

    /// <summary>
    /// Высота голоса.
    /// </summary>
    public float Pitch
    {
        get => _pitch;
        set => _pitch = Math.Clamp(value, -20, 20);
    }

    /// <inheritdoc cref="Emotion"/>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public Emotion Emotion { get; set; }

    /// <summary>
    /// Сериализует <see cref="Request"/>.
    /// </summary>
    /// <returns>Строка, представляющая <see cref="Request"/>.</returns>
    public string Serialize()
    {
        return JsonConvert.SerializeObject(this, s_settings);
    }

    private static string GetConfigurationValue(IConfiguration configuration, string key)
    {
        return configuration[key]
            ?? throw new KeyNotFoundException($"Не удалось найти ключ {key} в файле конфигурации.");
    }
}
