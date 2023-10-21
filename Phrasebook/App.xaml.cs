using Core.Models;

using Phrasebook.ViewModels;

using System.Text.Json;

namespace Phrasebook;

public partial class App : Application
{
	private static UserModel _userModel;

	internal static UserModel UserModel
	{
		get => _userModel;
		set
		{
			_userModel = value;
			Preferences.Set(nameof(UserModel), JsonSerializer.Serialize(value));
		}
	}

	public App(AppShellViewModel appShellViewModel)
	{
		InitializeComponent();

		MainPage = new AppShell(appShellViewModel);
	}
}
