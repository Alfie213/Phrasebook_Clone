using System.Diagnostics.CodeAnalysis;

namespace Phrasebook.DTO;

/// <summary>
/// Представляет тело ответа запроса.
/// </summary>
public readonly struct Response : IEquatable<Response>
{
	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="isSuccessful">Указывает, выполнился ли запрос успешно.</param>
	public Response(bool isSuccessful)
	{
		IsSuccessful = isSuccessful;
	}

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="message">Сообщение, полученное в качестве ответа.</param>
	public Response(string message)
	{
		Message = message;
	}

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="isSuccessful">Указывает, выполнился ли запрос успешно.</param>
	/// <param name="message">Сообщение, полученное в качестве ответа.</param>
	public Response(bool isSuccessful, string message)
	{
		IsSuccessful = isSuccessful;
		Message = message;
	}

	/// <summary>
	/// Указывает, выполнился ли запрос успешно.
	/// </summary>
	public bool IsSuccessful { get; }

	/// <summary>
	/// Сообщение, полученное в качестве ответа.
	/// </summary>
	public string Message { get; }

	/// <inheritdoc/>
	public bool Equals(Response other)
	{
		return (IsSuccessful == other.IsSuccessful)
			&& (Message == other.Message);
	}

	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] object obj)
	{
		return obj is Response other
			&& IsSuccessful == other.IsSuccessful
			&& Message == other.Message;
	}

	/// <inheritdoc/>
	public override int GetHashCode()
	{
		return HashCode.Combine(IsSuccessful, Message);
	}

	/// <summary>
	/// Проверяет, равны ли два <see cref="Response"/>.
	/// </summary>
	/// <param name="left">Левый операнд.</param>
	/// <param name="right">Правый операнд.</param>
	/// <returns>
	/// <see langword="true"/>, если значения левого и правого экземпляров полностью совпадают,
	/// иначе - <see langword="false"/>.
	/// </returns>
	public static bool operator ==(Response left, Response right)
	{
		return left.Equals(right);
	}

	/// <summary>
	/// Проверяет, не равны ли два <see cref="Response"/>.
	/// </summary>
	/// <param name="left">Левый операнд.</param>
	/// <param name="right">Правый операнд.</param>
	/// <returns>
	/// <see langword="true"/>, если левый и правый экземпляры отличаются хотя бы по одному значению,
	/// иначе - <see langword="false"/>.
	/// </returns>
	public static bool operator !=(Response left, Response right)
	{
		return !left.Equals(right);
	}
}
