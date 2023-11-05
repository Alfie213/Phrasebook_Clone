using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Identity.Pages;

/// <summary>
/// Главная страница.
/// </summary>
public class IndexModel : PageModel
{
	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="localizer">Локализатор.</param>
	public IndexModel(IStringLocalizer<IndexModel> localizer)
	{
		Localizer = localizer;
	}

	/// <summary>
	/// Локализатор.
	/// </summary>
	public IStringLocalizer<IndexModel> Localizer { get; }
}
