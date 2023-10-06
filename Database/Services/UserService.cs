using Core.Interfaces;
using Core.Models;

using Microsoft.AspNetCore.Identity;

namespace Database.Services;

/// <inheritdoc cref="IUserService"/>
public class UserService : IUserService
{
	private readonly DbSet<IdentityUser> _users;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="context">Контекст базы данных.</param>
	public UserService(Context context)
	{
		_users = context.Users;
	}

	/// <inheritdoc/>
	public async Task<UserModel?> GetUserModelAsync(string userId)
	{
        return await _users.Where(user => user.Id == userId)
			.Select(user => new UserModel
			{
				// TODO: Исправить базовую реализацию почту, чтобы она была обязательной.
				Email = user.Email ?? string.Empty
			}).FirstOrDefaultAsync();
	}
}
