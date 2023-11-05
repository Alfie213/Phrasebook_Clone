using CommunityToolkit.Mvvm.ComponentModel;

using Core.Models;

namespace Phrasebook.ViewModels;

/// <summary>
/// Модель отображения для <see cref="Lea"/>
/// </summary>
public sealed partial class LearnPageViewModel : ObservableObject
{
	private readonly HttpClient _client;

	public LearnPageViewModel(HttpClient client)
	{
		_client = client;
	}

	//public ObservableList<CardModel> Cards { get; set; }
}
