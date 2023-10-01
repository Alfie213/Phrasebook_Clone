using CommunityToolkit.Mvvm.Input;

using Phrasebook.Views.Account;

namespace Phrasebook.ViewModels;

public sealed partial class AppShellViewModel : BaseViewModel
{
    [RelayCommand]
    private async Task SingOutAsync()
    {
        if (Preferences.ContainsKey(nameof(App.User)))
        {
            Preferences.Remove(nameof(App.User));
        }

        await Shell.Current.GoToAsync($"{nameof(SignInPage)}");
    }
}
