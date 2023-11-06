namespace Phrasebook.Services;

internal sealed class CardService
{
	private readonly HttpClient _httpClient;

	public CardService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	//public async Task<IEnumerable> GetCards()
	//{
	//	var endpoint = new Uri("");
	//}
}
