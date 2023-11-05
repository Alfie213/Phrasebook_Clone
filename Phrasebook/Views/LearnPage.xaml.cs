using Phrasebook.ViewModels;

namespace Phrasebook.Views;

public partial class LearnPage : ContentPage
{
	public LearnPage(LearnPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
