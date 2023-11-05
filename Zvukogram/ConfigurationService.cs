using Microsoft.Extensions.Configuration;

namespace Zvukogram;

internal class ConfigurationService
{
	private static ConfigurationService? _instance;

	private ConfigurationService()
	{
		Configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.AddUserSecrets<ZvukogramService>()
			.Build();
	}

	public static ConfigurationService Instance => _instance ??= new ConfigurationService();

	public IConfiguration Configuration { get; }
}
