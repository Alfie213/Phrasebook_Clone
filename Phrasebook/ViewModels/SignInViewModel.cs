using CommunityToolkit.Mvvm.ComponentModel;

namespace Phrasebook.ViewModels;

internal sealed partial class SignInViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;
}
