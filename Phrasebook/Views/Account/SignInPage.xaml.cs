using Phrasebook.ViewModels;

namespace Phrasebook.Views.Account;

public partial class SignInPage : ContentPage
{
	public SignInPage(SignInViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}