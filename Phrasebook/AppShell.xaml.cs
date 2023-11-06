using Phrasebook.ViewModels;
using Phrasebook.Views.Account;

namespace Phrasebook;

public partial class AppShell : Shell
{
	public AppShell(AppShellViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;

		Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
	}
}
