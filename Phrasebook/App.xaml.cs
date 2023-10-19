using Core.Models;

using Phrasebook.ViewModels;

namespace Phrasebook;

public partial class App : Application
{
    internal static string Token { get; set; }
    internal static UserModel UserModel { get; set; }

    public App(AppShellViewModel appShellViewModel)
    {
        InitializeComponent();

        MainPage = new AppShell(appShellViewModel);
    }
}
