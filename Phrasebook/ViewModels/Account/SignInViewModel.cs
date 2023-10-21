using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Phrasebook.PartialViews;
using Phrasebook.Services;
using Phrasebook.Views;
using Phrasebook.Views.Account;

using System.Net.Http.Headers;

namespace Phrasebook.ViewModels;

public sealed partial class SignInViewModel : ObservableObject
{
	private readonly AppShellViewModel _appShellViewModel;
	private readonly IAuthenticationService _authenticationService;
	private readonly FlyoutHeader _flyoutHeader;
	private readonly HttpClient _client;
	private readonly IUserService _userService;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignInCommand))]
	private string _email = "test@gmail.com";

	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignInCommand))]
	private string _password = "Qte_653168";

	public SignInViewModel(AppShellViewModel appShellViewModel,
		IAuthenticationService service,
		FlyoutHeader flyoutHeader,
		HttpClient client,
		IUserService userService)
	{
		_appShellViewModel = appShellViewModel;
		_authenticationService = service;
		_flyoutHeader = flyoutHeader;
		_client = client;
		_userService = userService;
	}

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

		Shell.Current.FlyoutHeader = _flyoutHeader;
		await Shell.Current.GoToAsync($"//{nameof(LearnPage)}");
	}

	[RelayCommand]
	private async Task GoToRegistrationAsync()
	{
		await Shell.Current.GoToAsync(nameof(RegistrationPage));
	}

	private bool CanSignIn()
	{
		return Email.Length > 0 && Password.Length > 0;
	}
}
