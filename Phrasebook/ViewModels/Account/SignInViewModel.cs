using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Phrasebook.PartialViews;
using Phrasebook.Services;
using Phrasebook.Views;
using Phrasebook.Views.Account;

using System.Net.Http.Headers;

namespace Phrasebook.ViewModels;

/// <summary>
/// Модель отображения для страницы входа.
/// </summary>
public sealed partial class SignInViewModel : ObservableObject
{
	private readonly IAuthenticationService _authenticationService;
	private readonly FlyoutHeader _flyoutHeader;
	private readonly HttpClient _client;

	/// <summary>
	/// Почта.
	/// </summary>
	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignInCommand))]
	private string _email = "test@gmail.com";

	/// <summary>
	/// Пароль.
	/// </summary>
	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignInCommand))]
	private string _password = "Qte_653168";

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="service">Сервис авторизации.</param>
	/// <param name="flyoutHeader">Шапка меню.</param>
	/// <param name="client">HTTP клиент.</param>
	public SignInViewModel(IAuthenticationService service, FlyoutHeader flyoutHeader, HttpClient client)
	{
		_authenticationService = service;
		_flyoutHeader = flyoutHeader;
		_client = client;
	}

	/// <summary>
	/// Авторизует пользователя.
	/// </summary>
	[RelayCommand(CanExecute = nameof(CanSignIn))]
	private async Task SignInAsync()
	{
		var response = await _authenticationService.AuthenticateAsync(Email, Password);

		if (!response.IsSuccessful)
		{
			await Shell.Current.CurrentPage.DisplayAlert("Не удалось войти", response.Message, "Закрыть");
			return;
		}

		_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Body);

		await GoToMainPageAsync();
	}

	/// <summary>
	/// Открывает страницу регистрации.
	/// </summary>
	[RelayCommand]
	private async Task GoToRegistrationAsync()
	{
		await Shell.Current.GoToAsync(nameof(RegistrationPage));
	}

	private bool CanSignIn()
	{
		return Email.Length > 0 && Password.Length > 0;
	}

	private async Task GoToMainPageAsync()
	{
		Shell.Current.FlyoutHeader = _flyoutHeader;
		await Shell.Current.GoToAsync($"//{nameof(LearnPage)}");
	}
}
