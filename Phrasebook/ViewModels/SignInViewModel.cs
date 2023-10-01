using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Phrasebook.ViewModels;

internal sealed partial class SignInViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    [RelayCommand]
    private async Task SignInAsync()
    {
        throw new NotImplementedException();
    }
}
