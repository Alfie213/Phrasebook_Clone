namespace Phrasebook.PartialViews;

public partial class FlyoutHeader : ContentView
{
	public FlyoutHeader()
	{
		InitializeComponent();

		if (App.UserModel is not null)
		{
			username.Text = $"Signed in as {App.UserModel.Email}";
			email.Text = App.UserModel.Email;
		}
	}
}