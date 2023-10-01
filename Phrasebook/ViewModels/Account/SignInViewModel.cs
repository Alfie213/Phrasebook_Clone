using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Phrasebook.Models;
using Phrasebook.PartialViews;
using Phrasebook.Services;
using Phrasebook.Views;

using System.Text.Json;

namespace Phrasebook.ViewModels;

public sealed partial class SignInViewModel : BaseViewModel
{
    private readonly ISignInService _service;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SignInCommand))]
    private string _email = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SignInCommand))]
    private string _password = string.Empty;

    public SignInViewModel(ISignInService service)
    {
        _service = service;
    }

    [RelayCommand(CanExecute = nameof(CanSignIn))]
    private async Task SignInAsync()
    {
        var user = await _service.SignInAsync(Email, Password);

        UpdatePreferences(user);

        Shell.Current.FlyoutHeader = new FlyoutHeader();

        await Shell.Current.GoToAsync($"{nameof(LearnPage)}");
    }

    private static void UpdatePreferences(User user)
    {
        if (Preferences.ContainsKey(nameof(App.User)))
        {
            Preferences.Remove(nameof(App.User));
        }

        var serializedUser = JsonSerializer.Serialize(user);
        Preferences.Set(nameof(App.User), serializedUser);

        App.User = user;
    }

    private bool CanSignIn()
    {
        return Email.Length > 0 && Password.Length > 0;
    }
}
