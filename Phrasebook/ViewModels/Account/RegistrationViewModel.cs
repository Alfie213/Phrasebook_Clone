using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Phrasebook.Services;

namespace Phrasebook.ViewModels.Account;

public sealed partial class RegistrationViewModel : ObservableObject
{
	private readonly IRegistrationService _registrationService;
	private readonly SignInViewModel _signInViewModel;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
	private string _email = "test1@gmail.com";

	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
	private string _password = "qqqqqq";

	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
	private string _confirmedPassword = "qqqqqq";

	public RegistrationViewModel(IRegistrationService registrationService, SignInViewModel signInViewModel)
	{
		_registrationService = registrationService;
		_signInViewModel = signInViewModel;
	}

	[RelayCommand]
	private static async Task BackToSignInAsync()
	{
		await Shell.Current.Navigation.PopAsync();
	}

	[RelayCommand(CanExecute = nameof(CanSignUp))]
	private async Task SignUpAsync()
	{
		var response = await _registrationService.SignUp(Email, Password);

		if (!response.IsSuccessful)
		{
			await Shell.Current.CurrentPage.DisplayAlert("Не удалось зарегистрироваться", response.Message, "Закрыть");
			return;
		}

		SetRegistrationCredentialsToSignInPage();

		await Shell.Current.Navigation.PopAsync();
	}

	private void SetRegistrationCredentialsToSignInPage()
	{
		_signInViewModel.Email = Email;
		_signInViewModel.Password = Password;
	}

	// TODO: Сделать удаленную проверку, что пароля не существует
	private bool CanSignUp()
	{
		var entriesNotEmpty = !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmedPassword);
		var passwordsMatch = Password == ConfirmedPassword;

		return entriesNotEmpty && passwordsMatch;
	}
}
