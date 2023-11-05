using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Identity.Pages.Components;

/// <summary>
/// Заголовок страницы.
/// </summary>
public partial class Header
{
	/// <summary>
	/// Локализатор.
	/// </summary>
	[Inject]
	private IStringLocalizer<Header> Localizer { get; init; } = null!;
}
