using Phrasebook.Models;
using Phrasebook.ViewModels;
using Phrasebook.Views;

namespace Phrasebook;

public partial class App : Application
{
    internal static User User { get; set; }

    public App(AppShellViewModel appShellViewModel)
    {
        InitializeComponent();

        MainPage = new AppShell(appShellViewModel);
    }
}
