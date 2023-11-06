using Core.Models;

using Phrasebook.DTO;

using System.Net.Http.Json;

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

		var endpoint = new Uri("registration", UriKind.Relative);
		var content = new RegistrationModel(email, password);

		try
		{
			var response = await _client.PostAsJsonAsync(endpoint, content);

			if (!response.IsSuccessStatusCode)
			{
				var errors = await response.Content.ReadAsStringAsync();
				return new Response(errors);
			}

			return new Response(true);
		}
		catch (HttpRequestException)
		{
			return new Response("Не удалось отправить запрос");
		}
	}
}
