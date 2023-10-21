using System.Diagnostics.CodeAnalysis;

namespace Core.Models;

/// <summary>
/// Модель для регистрации пользователя.
/// </summary>
[Serializable]
public sealed class RegistrationModel
{
	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="email">Почта.</param>
	/// <param name="password">Пароль.</param>
	[SetsRequiredMembers]
	public RegistrationModel(string email, string password)
	{
		Email = email;
		Password = password;
	}

	/// <summary>
	/// Почта.
	/// </summary>
	public required string Email { get; set; }

	/// <summary>
	/// Пароль.
	/// </summary>
	public required string Password { get; set; }
}
