namespace Identity.Extensions;

/// <summary>
/// Расширяющий класс для высокопроизводительного логирования.
/// </summary>
public static class LoggerExtension
{
	private static readonly Action<ILogger, Exception?> _userRegistered = LoggerMessage.Define(
	LogLevel.Information,
	new EventId(1, nameof(UserRegistered)),
	"Пользователь успешно зарегистрировался.");

	/// <summary>
	/// Информирует об успешной регистрации пользователя.
	/// </summary>
	/// <param name="logger">Логгер.</param>
	public static void UserRegistered(this ILogger logger)
	{
		_userRegistered?.Invoke(logger, null);
	}
}
