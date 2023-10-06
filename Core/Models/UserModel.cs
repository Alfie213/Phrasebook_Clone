namespace Core.Models;

/// <summary>
/// Модель для передачи информации о пользователе.
/// </summary>
public sealed class UserModel
{
    /// <summary>
    /// Почта.
    /// </summary>
    public required string Email { get; set; }
}
