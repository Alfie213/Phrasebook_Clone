using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Identity.Pages.Components;

/// <summary>
/// Блок "О приложении".
/// </summary>
public partial class About
{
	/// <summary>
	/// Локализатор.
	/// </summary>
	[Inject]
	public IStringLocalizer<About> Localizer { get; init; } = null!;
}
