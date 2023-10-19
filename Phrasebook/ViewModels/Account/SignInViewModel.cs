using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Core.Models;

using Phrasebook.PartialViews;
using Phrasebook.Services;
using Phrasebook.Views;
using Phrasebook.Views.Account;

using System.Net.Http.Headers;
using System.Text.Json;

namespace Phrasebook.ViewModels;

public sealed partial class SignInViewModel : BaseViewModel
{
	private readonly HttpClient _client;
	private readonly IAuthenticationService _authenticationService;
	private readonly IUserService _userService;
	private readonly AppShellViewModel _appShellViewModel;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignInCommand))]
	private string _email = "test@gmail.com";

	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignInCommand))]
	private string _password = "Qte_653168";

	public SignInViewModel(HttpClient client, IAuthenticationService service, IUserService userService, AppShellViewModel appShellViewModel)
	{
		_client = client;
		_authenticationService = service;
		_userService = userService;
		_appShellViewModel = appShellViewModel;
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

		var token = response.Message;
		_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

		var user = await _userService.GetUserModelAsync();

		UpdatePreferences(token);
		UpdatePreferences(user);

		Shell.Current.FlyoutHeader = new FlyoutHeader();
		await Shell.Current.GoToAsync($"//{nameof(LearnPage)}");
	}

	[RelayCommand]
	private async Task GoToRegistrationAsync()
	{
		await Shell.Current.GoToAsync(nameof(RegistrationPage));
	}

	private static void UpdatePreferences(string token)
	{
		if (Preferences.ContainsKey(nameof(App.Token)))
		{
			Preferences.Remove(nameof(App.Token));
		}

		Preferences.Set(nameof(App.Token), token);
		App.Token = token;
	}

	private static void UpdatePreferences(UserModel userModel)
	{
		if (Preferences.ContainsKey(nameof(App.UserModel)))
		{
			Preferences.Remove(nameof(App.UserModel));
		}

		Preferences.Set(nameof(App.UserModel), JsonSerializer.Serialize(userModel));
		App.UserModel = userModel;
	}

	private bool CanSignIn()
	{
		return Email.Length > 0 && Password.Length > 0;
	}
}
