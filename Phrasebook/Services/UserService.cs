using Core.Models;

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
	public async Task<UserModel> GetUserModelAsync()
	{
		return await _client.GetFromJsonAsync<UserModel>("user");
	}
}
