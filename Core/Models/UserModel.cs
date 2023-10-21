namespace Core.Models;

/// <summary>
/// Модель для передачи информации о пользователе.
/// </summary>
public sealed class UserModel
{
	//private static readonly Lazy<UserModel> _empty = new();

	///// <summary>
	///// Модель со стандартными значениями.
	///// </summary>
	//public static UserModel Empty => _empty.Value;

	/// <summary>
	/// Почта.
	/// </summary>
	public required string Email { get; init; }
}
