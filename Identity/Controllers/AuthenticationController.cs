using Identity.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identity.Controllers;

/// <summary>
/// Контроллер для аутентификации пользователя.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly TokenService _tokenService;

    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="userManager"><see cref="UserManager{TUser}"/>.</param>
    /// <param name="tokenService">Сервис для работы с JWT токеном.</param>
    public AuthenticationController(UserManager<IdentityUser> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [HttpGet("/token")]
    public async Task<IActionResult> GetTokenAsync(string email, string password)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest($"{email} не может быть пустым.");
        }

        if (string.IsNullOrEmpty(password))
        {
            return BadRequest($"{password} не может быть пустым.");
        }

        var user = await _userManager.FindByEmailAsync(email);

        if (user is not null && await _userManager.CheckPasswordAsync(user, password))
        {
            var claims = new Claim[]
            {
                new (JwtRegisteredClaimNames.Sub, user.Id),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = _tokenService.CreateToken(claims);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        return BadRequest("Введены неверные учетные данные.");
    }
}
