namespace Curl.Exceptions.Arguments;

/// <summary>
/// Represents an exception thrown when a required argument value is missing.
/// </summary>
public class MissingArgumentValueException : CommandArgumentException
{
    public MissingArgumentValueException(string flag) : base($"Missing value for argument: -{flag}")
    {
    }
}