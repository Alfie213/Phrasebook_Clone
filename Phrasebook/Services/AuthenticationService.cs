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
	public async Task<Response> AuthenticateAsync(string email, string password)
	{
		if (Connectivity.NetworkAccess != NetworkAccess.Internet)
		{
			return new Response("Нет соединения с Интернетом");
		}

		var endpoint = new Uri($"authentication/token?email={email}&password={password}", UriKind.Relative);
		var response = await _client.GetAsync(endpoint);

		return new Response(response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
	}
}
