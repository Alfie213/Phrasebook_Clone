using Phrasebook.ViewModels;
using Phrasebook.Views;

namespace Phrasebook;

public partial class AppShell : Shell
{
    public AppShell(AppShellViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;

        Routing.RegisterRoute(nameof(LearnPage), typeof(LearnPage));
    }
}
