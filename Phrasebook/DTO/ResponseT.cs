using System.Diagnostics.CodeAnalysis;

namespace Phrasebook.DTO;

/// <typeparam name="T">Тип объекта, возвращаемый из запроса.</typeparam>
/// <inheritdoc cref="Response"/>
public readonly struct Response<T> : IEquatable<Response<T>> where T : class
{
	/// <inheritdoc cref="Response(bool)"/>
	public Response(bool isSuccessful)
	{
		IsSuccessful = isSuccessful;
	}

	/// <inheritdoc cref="Response(string)"/>
	public Response(string message)
	{
		Message = message;
	}

	/// <inheritdoc cref="Response(bool, string)"/>
	public Response(bool isSuccessful, string message)
	{
		IsSuccessful = isSuccessful;
		Message = message;
	}

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="isSuccessful">Указывает, выполнился ли запрос успешно.</param>
	/// <param name="body">Объект, возвращаемый из запроса.</param>
	public Response(bool isSuccessful, T body)
	{
		IsSuccessful = isSuccessful;
		Body = body;
	}

	/// <inheritdoc cref="Response.IsSuccessful"/>
	public bool IsSuccessful { get; }

	/// <inheritdoc cref="Response.Message"/>
	public string Message { get; }

	/// <summary>
	/// Объект, возвращаемый из запроса.
	/// </summary>
	public T Body { get; }

	/// <inheritdoc/>
	public bool Equals(Response<T> other)
	{
		return (IsSuccessful == other.IsSuccessful)
			&& (Message == other.Message)
			&& Body.Equals(other.Body);
	}

	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] object obj)
	{
		return obj is Response<T> other
			&& IsSuccessful == other.IsSuccessful
			&& Message == other.Message
			&& Body.Equals(other.Body);
	}

	/// <inheritdoc/>
	public override int GetHashCode()
	{
		return HashCode.Combine(IsSuccessful, Message, Body);
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
	public static bool operator ==(Response<T> left, Response<T> right)
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
	public static bool operator !=(Response<T> left, Response<T> right)
	{
		return !left.Equals(right);
	}
}
