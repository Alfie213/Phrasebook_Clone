using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Phrasebook.Services;

namespace Phrasebook.ViewModels.Account;

/// <summary>
/// Модель отображения для страницы регистрации.
/// </summary>
public sealed partial class RegistrationViewModel : ObservableObject
{
	private readonly IRegistrationService _registrationService;
	private readonly SignInViewModel _signInViewModel;

	/// <summary>
	/// Почта.
	/// </summary>
	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
	private string _email = "test1@gmail.com";

	/// <summary>
	/// Пароль.
	/// </summary>
	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
	private string _password = "qqqqqq";

	/// <summary>
	/// Подтверждённый пароль.
	/// </summary>
	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
	private string _confirmedPassword = "qqqqqq";

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="registrationService">Сервис регистрации.</param>
	/// <param name="signInViewModel">Модель отображения для страницы входа.</param>
	public RegistrationViewModel(IRegistrationService registrationService, SignInViewModel signInViewModel)
	{
		_registrationService = registrationService;
		_signInViewModel = signInViewModel;
	}

	/// <summary>
	/// Открывает предыдущую страницу - страницу входа.
	/// </summary>
	[RelayCommand]
	private static async Task BackToSignInAsync()
	{
		await Shell.Current.Navigation.PopAsync();
	}

	/// <summary>
	/// Регистрирует пользователя.
	/// </summary>
	/// <returns></returns>
	[RelayCommand(CanExecute = nameof(CanSignUp))]
	private async Task SignUpAsync()
	{
		var response = await _registrationService.SignUp(Email, Password);

		if (!response.IsSuccessful)
		{
			await Shell.Current.CurrentPage.DisplayAlert("Не удалось зарегистрироваться", response.Message, "Закрыть");
			return;
		}

		await BackToSignInPageWithFilledCredentialsAsync();
	}

	private async Task BackToSignInPageWithFilledCredentialsAsync()
	{
		SetRegistrationCredentialsToSignInPage();
		await BackToSignInAsync();
	}

	private void SetRegistrationCredentialsToSignInPage()
	{
		_signInViewModel.Email = Email;
		_signInViewModel.Password = Password;
	}

	private bool CanSignUp()
	{
		var entriesNotEmpty = !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmedPassword);
		var passwordsMatch = Password == ConfirmedPassword;

		return entriesNotEmpty && passwordsMatch;
	}
}
