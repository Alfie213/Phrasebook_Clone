using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Phrasebook.Views.Account;

using System.Net;

namespace Phrasebook.ViewModels;

/// <summary>
/// Модель отображения для <see cref="AppShell"/>.
/// </summary>
public sealed partial class AppShellViewModel : ObservableObject
{
	private readonly HttpClient _client;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="client">HTTP клиент.</param>
	public AppShellViewModel(HttpClient client)
	{
		_client = client;
	}

	[RelayCommand]
	private async Task SignOutAsync()
	{
		_client.DefaultRequestHeaders.Remove(HttpRequestHeader.Authorization.ToString());

		await Shell.Current.GoToAsync($"//{nameof(SignInPage)}");
	}
}
