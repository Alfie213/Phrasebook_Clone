using Core.Models;

using Phrasebook.DTO;

using System.Net.Http.Json;

namespace Phrasebook.Services;

/// <inheritdoc cref="IUserService"/>
public sealed class UserService : IUserService
{
	private readonly HttpClient _client;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="client">HTTP клиент.</param>
	public UserService(HttpClient client)
	{
		_client = client;
	}

	/// <inheritdoc/>
	public async Task<Response<UserModel>> GetUserModelAsync()
	{
		var endpoint = new Uri("user", UriKind.Relative);

		try
		{
			var user = await _client.GetFromJsonAsync<UserModel>(endpoint);
			return new Response<UserModel>(true, user);
		}
		catch (HttpRequestException)
		{
			return new Response<UserModel>("Не удалось получить информацию о пользователе");
		}
	}
}
