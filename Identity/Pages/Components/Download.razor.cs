using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Identity.Pages.Components;

/// <summary>
/// Блок "Скачать".
/// </summary>
public partial class Download
{
	/// <summary>
	/// Локализатор.
	/// </summary>
	[Inject]
	private IStringLocalizer<Download> Localizer { get; init; } = null!;
}
