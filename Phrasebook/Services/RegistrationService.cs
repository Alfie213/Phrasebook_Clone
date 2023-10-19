using Phrasebook.DTO;

using System.Text;

using System.Text.Json;

namespace Phrasebook.Services;

/// <inheritdoc cref="IRegistrationService"/>
public sealed class RegistrationService : IRegistrationService
{
	private readonly HttpClient _client;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="client">HTTP клиент.</param>
	public RegistrationService(HttpClient client)
	{
		_client = client;
	}

	/// <inheritdoc/>
	public async Task<Response> SignUp(string email, string password)
	{
		if (Connectivity.NetworkAccess != NetworkAccess.Internet)
		{
			return new Response("Нет соединения с Интернетом");
		}

		var content = new { email, password };
		//var response = await _client.PostAsJsonAsync("registration", content);


		var json = JsonSerializer.Serialize(content);
		using var content2 = new StringContent(json, Encoding.UTF8, "application/json");

		var response = await _client.PostAsync("registration", content2);

		if (!response.IsSuccessStatusCode)
		{
			var errors = await response.Content.ReadAsStringAsync();
			return new Response(errors);
		}

		return new Response(true);
	}
}
