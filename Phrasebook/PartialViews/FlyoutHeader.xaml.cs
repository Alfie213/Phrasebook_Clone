namespace Phrasebook.PartialViews;

public partial class FlyoutHeader : ContentView
{
	public FlyoutHeader()
	{
		InitializeComponent();

		if (App.User is not null)
		{
			username.Text = $"Signed in as {App.User.Username}";
			email.Text = App.User.Username;
		}
	}
}