using Moq;

using Zvukogram;
using Zvukogram.Request;

namespace ZvukogramTests;

[TestClass]
public class ServiceTests
{
	private readonly HttpClient _client;
	private readonly Mock<ZvukogramService> _service;

	public ServiceTests()
	{
		_client = new HttpClient();

		var initialData = new Dictionary<string, string?>
		{
			["api"] = "api",
		};

		var configuration = Helper.CreateConfiguration(initialData);
		_service = new Mock<ZvukogramService>(_client, configuration);
	}

	[TestMethod]
	public async Task GetAudioAsync()
	{
		const string response = "{\"id\":\"24133773\",\"status\":1," +
			"\"file\":\"https:\\/\\/zvukogram.com\\/texttomp3\\/20230919\\/" +
			"prj_24038748_d41d8cd98f00b204e9800998ecf8427e_1695146419.ogg\"," +
			"\"file_cors\":\"https:\\/\\/zvukogram.com\\/index.php?r=site\\/download&prj=24133773" +
			"&cors=4c13a0784fc76cedd62d400b25c105c6\"," +
			"\"parts\":0,\"parts_done\":0,\"duration\":\"1\",\"format\":\"ogg\",\"error\":\"\",\"balans\":\"246.063\"," +
			"\"cost\":\"0\"}";

		var expected = new Uri("https://zvukogram.com/texttomp3/20230919/prj_24038748_d41d8cd98f00b204e9800998ecf8427e_1695146419.ogg");

		_service.Setup(x => x.SendRequestAsync(It.IsAny<Parameters>()))
			.ReturnsAsync(response);

		var result = await _service.Object.GetAudioAsync(It.IsAny<Parameters>());

		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	public async Task FailedGetAudioAsync()
	{
		const string response = "{\"id\":0,\"status\":0,\"file\":\"\",\"file_cors\":\"\",\"parts\":0,\"parts_done\":0,\"duration\":0,\"format\":\"mp3\",\"error\":\"Not correct voice\",\"balans\":\"246.063\"}";

		_service.Setup(x => x.SendRequestAsync(It.IsAny<Parameters>()))
			.ReturnsAsync(response);

		var result = await _service.Object.GetAudioAsync(It.IsAny<Parameters>());

		Assert.IsNull(result);
	}

	[ClassCleanup]
	public void Cleanup()
	{
		_client.Dispose();
	}
}
