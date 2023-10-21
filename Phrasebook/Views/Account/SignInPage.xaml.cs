using Phrasebook.ViewModels;

using System.ComponentModel;

namespace Phrasebook.Views.Account;

public partial class SignInPage : ContentPage
{
	public SignInPage(SignInViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

	private void OnSpinnerPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(spinner.IsVisible))
		{
			signInButton.IsVisible = !spinner.IsVisible;
		}
	}
}
