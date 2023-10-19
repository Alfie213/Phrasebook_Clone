using System.Diagnostics.CodeAnalysis;

namespace Phrasebook.DTO;

public readonly struct Response : IEquatable<Response>
{
	public Response(bool isSuccessful)
	{
		IsSuccessful = isSuccessful;
	}

	public Response(string message)
	{
		Message = message;
	}

	public Response(bool isSuccessful, string message)
	{
		IsSuccessful = isSuccessful;
		Message = message;
	}

	public bool IsSuccessful { get; }
	public string Message { get; }

	public bool Equals(Response other)
	{
		return (IsSuccessful == other.IsSuccessful) && (Message == other.Message);
	}

	public override bool Equals([NotNullWhen(true)] object obj)
	{
		return obj is Response other
			&& IsSuccessful == other.IsSuccessful
			&& Message == other.Message;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(IsSuccessful, Message);
	}

	public static bool operator ==(Response left, Response right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(Response left, Response right)
	{
		return !left.Equals(right);
	}
}
