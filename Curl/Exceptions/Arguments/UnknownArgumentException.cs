namespace Curl.Exceptions.Arguments;

/// <summary>
/// Represents an exception thrown when an unknown argument is provided.
/// </summary>
public class UnknownArgumentException : CommandArgumentException
{
    public UnknownArgumentException(string flag) : base($"Unknown argument: -{flag}")
    {
    }
}