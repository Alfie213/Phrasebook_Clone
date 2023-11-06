using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Identity.Pages.Components;

/// <summary>
/// Подвал сайта.
/// </summary>
public partial class Footer
{
	/// <summary>
	/// Локализатор.
	/// </summary>
	[Inject]
	private IStringLocalizer<Footer> Localizer { get; init; } = null!;
}
