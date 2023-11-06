using Core.Interfaces;

using Identity.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public sealed class UserController : ControllerBase
{
	private readonly TokenService _tokenService;
	private readonly IUserService _userService;

	public UserController(TokenService tokenService, IUserService userService)
	{
		_tokenService = tokenService;
		_userService = userService;
	}

	[HttpGet]
	public async Task<IActionResult> GetInformationAsync()
	{
		var userId = _tokenService.GetUserId(Request);
		var user = await _userService.GetUserModelAsync(userId);

		return Ok(user);
	}
}
