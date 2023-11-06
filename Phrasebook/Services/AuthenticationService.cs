using Phrasebook.DTO;

namespace Phrasebook.Services;

/// <inheritdoc cref="IAuthenticationService"/>
public sealed class AuthenticationService : IAuthenticationService
{
	private readonly HttpClient _client;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="client">HTTP клиент.</param>
	public AuthenticationService(HttpClient client)
	{
		_client = client;
	}

	/// <inheritdoc />
	public async Task<Response<string>> AuthenticateAsync(string email, string password)
	{
		if (Connectivity.NetworkAccess != NetworkAccess.Internet)
		{
			return new Response<string>("Нет соединения с Интернетом");
		}

		try
		{
			var endpoint = new Uri($"authentication/token?email={email}&password={password}", UriKind.Relative);
			var response = await _client.GetAsync(endpoint);

			return new Response<string>(response.IsSuccessStatusCode, body: await response.Content.ReadAsStringAsync());
		}
		catch (HttpRequestException)
		{
			return new Response<string>("Не удалось отправить запрос");
		}
	}
}
