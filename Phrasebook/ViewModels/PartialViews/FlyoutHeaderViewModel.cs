using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Phrasebook.Services;

namespace Phrasebook.ViewModels.PartialViews;

public sealed partial class FlyoutHeaderViewModel : ObservableObject
{
	private readonly IUserService _userService;

	[ObservableProperty]
	private string _username;

	[ObservableProperty]
	private string _email;

	public FlyoutHeaderViewModel(IUserService userService)
	{
		_userService = userService;
	}

	[RelayCommand]
	private async Task DisplayUserInformationAsync()
	{
		if (App.UserModel is null)
		{
			var response = await _userService.GetUserModelAsync();

			if (response.IsSuccessful)
			{
				App.UserModel = response.Body;
				SetUserInformation();
			}
			else
			{
				await Shell.Current.CurrentPage.DisplayAlert("Ошибка", response.Message, "Закрыть");
			}
		}
		else
		{
			SetUserInformation();
		}
	}

	private void SetUserInformation()
	{
		Username = App.UserModel.Email;
		Email = App.UserModel.Email;
	}
}
