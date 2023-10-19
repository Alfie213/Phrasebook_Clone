using Phrasebook.ViewModels.Account;

namespace Phrasebook.Views.Account;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}