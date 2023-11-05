using Microsoft.Extensions.Configuration;

using Zvukogram.Request;

namespace ZvukogramTests;

[TestClass]
public class RequestTests
{
	private const float MinSpeed = 0.1f;
	private const byte MaxSpeed = 2;
	private const sbyte MinPitch = -20;
	private const byte MaxPitch = 20;

	private Body _request = null!;

	[TestInitialize]
	public void Initialize()
	{
		var initialData = new Dictionary<string, string?>
		{
			["email"] = "email",
			["token"] = "token"
		};

		var configuration = Helper.CreateConfiguration(initialData);

		_request = CreateBody(configuration);
	}

	[TestMethod]
	public void CannotCreateWithoutToken()
	{
		var initialData = new Dictionary<string, string?>
		{
			["email"] = "email"
		};

		var configuration = Helper.CreateConfiguration(initialData);

		Assert.ThrowsException<KeyNotFoundException>(() => CreateBody(configuration));
	}

	[TestMethod]
	public void CannotCreateWithoutEmail()
	{
		var initialData = new Dictionary<string, string?>
		{
			["token"] = "token"
		};

		var configuration = new ConfigurationBuilder()
			.AddInMemoryCollection(initialData)
			.Build();

		Assert.ThrowsException<KeyNotFoundException>(() => CreateBody(configuration));
	}

	[TestMethod]
	public void SpeedHasOneAsDefault()
	{
		Assert.AreEqual(1, _request.Speed);
	}

	[DataTestMethod]
	[DataRow(1)]
	[DataRow(MinPitch - 1)]
	[DataRow(MaxPitch + 1)]
	public void PitchMustBeInRange(float pitch)
	{
		_request.Pitch = pitch;

		if (pitch < MinPitch)
		{
			Assert.AreEqual(MinPitch, _request.Pitch);
		}
		else if (pitch > MaxPitch)
		{
			Assert.AreEqual(MaxPitch, _request.Pitch);
		}
		else
		{
			Assert.AreEqual(pitch, _request.Pitch);
		}
	}

	[DataTestMethod]
	[DataRow(1)]
	[DataRow(MinSpeed - 1)]
	[DataRow(MaxSpeed + 1)]
	public void SpeedMustBeInRange(float speed)
	{
		_request.Speed = speed;

		if (speed < MinSpeed)
		{
			Assert.AreEqual(MinSpeed, _request.Speed);
		}
		else if (speed > MaxSpeed)
		{
			Assert.AreEqual(MaxSpeed, _request.Speed);
		}
		else
		{
			Assert.AreEqual(speed, _request.Speed);
		}
	}

	[TestMethod]
	public void FormatHasMp3AsDefault()
	{
		Assert.AreEqual(Format.Mp3, _request.Format);
	}

	[TestMethod]
	public void EmotionHasGoodAsDefault()
	{
		Assert.AreEqual(Emotion.Good, _request.Emotion);
	}

	[TestMethod]
	public void Serialize()
	{
		const string expected = "{\"email\":\"email\",\"token\":\"token\",\"text\":\"text\",\"voice\":\"voice\"}";

		Assert.AreEqual(expected, _request.Serialize());
	}

	[DataTestMethod]
	[DataRow(Emotion.Evil)]
	[DataRow(Emotion.Neutral)]
	public void SerializeWithEmotionProvided(Emotion emotion)
	{
		_request.Emotion = emotion;

		var substring = $"\"emotion\":\"{emotion.ToString().ToLowerInvariant()}\"}}";
		var serialized = _request.Serialize();

		Assert.IsTrue(serialized.Contains(substring, StringComparison.Ordinal));
	}

	[DataTestMethod]
	[DataRow(Format.Ogg)]
	[DataRow(Format.Wav)]
	public void SerializeWithFormatProvided(Format format)
	{
		_request.Format = format;

		var serialized = _request.Serialize();
		var substring = $"\"format\":\"{format.ToString().ToLowerInvariant()}\"}}";

		Assert.IsTrue(serialized.Contains(substring, StringComparison.Ordinal));
	}

	[TestMethod]
	public void SerializeWithPitchProvided()
	{
		_request.Pitch = 3;

		var serialized = _request.Serialize();
		var substring = $"\"pitch\":{_request.Pitch}}}";

		Assert.IsTrue(serialized.EndsWith(substring, StringComparison.Ordinal));
	}

	[TestMethod]
	public void SerializeWithSpeedProvided()
	{
		_request.Speed = 3;

		var serialized = _request.Serialize();
		var substring = $"\"speed\":{_request.Speed}}}";

		Assert.IsTrue(serialized.EndsWith(substring, StringComparison.Ordinal));
	}

	[TestMethod]
	public void FloatSeparatorMustBeComma()
	{
		_request.Speed = 0.1f;

		var serialized = _request.Serialize();
		const string substring = $"\"speed\":0.1}}";

		Assert.IsTrue(serialized.EndsWith(substring, StringComparison.Ordinal));
	}

	private static Body CreateBody(IConfiguration configuration)
	{
		return new Body()
		{
			Text = "text",
			Voice = "voice"
		};
	}
}
