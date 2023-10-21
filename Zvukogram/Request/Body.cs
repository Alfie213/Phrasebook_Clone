using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

using Zvukogram.Json;

namespace Zvukogram.Request;

/// <summary>
/// Тело запроса.
/// </summary>
[Serializable]
internal sealed class Body
{
	/// <summary>
	/// Стандартное значение <see cref="Speed"/>.
	/// </summary>
	internal const float DefaultSpeed = 1;

	private static readonly JsonSerializerSettings _settings = new()
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

		Email = GetConfigurationValue(configuration, "Email");
		Token = GetConfigurationValue(configuration, "Token");
	}

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="configuration">Конфигурация.</param>
	/// <param name="parameters">Параметры запроса.</param>
	[SetsRequiredMembers]
	public Body(IConfiguration configuration, Parameters parameters) : this(configuration)
	{
		Text = parameters.Text;
		Voice = parameters.Voice;
		Format = parameters.Format;
		Speed = parameters.Speed;
		Pitch = parameters.Pitch;
		Emotion = parameters.Emotion;
	}

	/// <summary>
	/// Зарегистрированная почта.
	/// </summary>
	public string Email { get; }

	/// <summary>
	/// Секретный ключ для доступа к API, связанный с <see cref="Email"/>.
	/// </summary>
	public string Token { get; }

	/// <summary>
	/// Текст, который необходимо озвучить.
	/// </summary>
	public required string Text { get; init; }

	/// <summary>
	/// Голос, которым будет озвучен <see cref="Text"/>.
	/// </summary>
	public required string Voice { get; init; }

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
		return JsonConvert.SerializeObject(this, _settings);
	}

	private static string GetConfigurationValue(IConfiguration configuration, string key)
	{
		return configuration[key]
			?? throw new KeyNotFoundException(key);
	}
}
