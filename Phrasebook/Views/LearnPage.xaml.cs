namespace Phrasebook.Views;

public partial class LearnPage : ContentPage
{
	public LearnPage()
	{
		InitializeComponent();
	}

	//protected override bool OnNavigating(ShellNavigatingEventArgs args)
	//{
	//	// Check if it is a back navigation from the login page
	//	if (args.Source == ShellNavigationSource.Pop && args.Current.Location.OriginalString == "///login")
	//	{
	//		// Hide the back button
	//		Shell.SetBackButtonBehavior(Shell.Current, new BackButtonBehavior
	//		{
	//			IsEnabled = false
	//		});
	//	}

	//	return base.OnNavigating(args);
	//}
}