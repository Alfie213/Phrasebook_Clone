using Phrasebook.ViewModels.PartialViews;

namespace Phrasebook.PartialViews;

public partial class FlyoutHeader : ContentView
{
	public FlyoutHeader(FlyoutHeaderViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
		Loaded += (sender, e) => viewModel.DisplayUserInformationCommand.Execute(sender);
	}
}
