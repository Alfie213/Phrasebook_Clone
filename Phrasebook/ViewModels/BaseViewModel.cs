using CommunityToolkit.Mvvm.ComponentModel;

namespace Phrasebook.ViewModels;

internal partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string? _title;
}
