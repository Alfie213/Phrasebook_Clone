using Core.Models;

using Identity.Extensions;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers;

/// <summary>
/// Контроллер для регистрации пользователей.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public sealed class RegistrationController : ControllerBase
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly ILogger<RegistrationController> _logger;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="userManager"><see cref="UserManager{TUser}"/>.</param>
	/// <param name="logger">Логгер.</param>
	public RegistrationController(UserManager<IdentityUser> userManager, ILogger<RegistrationController> logger)
	{
		_userManager = userManager;
		_logger = logger;
	}

	/// <summary>
	/// Регистрирует пользователя.
	/// </summary>
	/// <param name="registrationModel">Модель для регистрации пользователя.</param>
	/// <returns>
	/// <see cref="StatusCodes.Status200OK"/>, если пользователь успешно зарегистрирован,
	/// иначе - <see cref="StatusCodes.Status400BadRequest"/> с информацией об ошибках.
	/// </returns>
	[HttpPost]
	public async Task<IActionResult> RegisterAsync([FromBody] RegistrationModel registrationModel)
	{
		if (registrationModel is null)
		{
			return BadRequest("Отсутствуют данные для регистрации");
		}

		var user = new IdentityUser
		{
			UserName = registrationModel.Email,
			Email = registrationModel.Email
		};

		var result = await _userManager.CreateAsync(user, registrationModel.Password);

		if (result.Succeeded)
		{
			_logger.UserRegistered();

			return Ok();
		}

		return BadRequest(result.Errors);
	}
}
