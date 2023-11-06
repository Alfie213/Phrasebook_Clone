using Phrasebook.ViewModels.Account;

using System.ComponentModel;

namespace Phrasebook.Views.Account;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationViewModel viewModel)
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
