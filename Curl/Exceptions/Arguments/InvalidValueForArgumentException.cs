namespace Curl.Exceptions.Arguments;

/// <summary>
/// Represents an exception thrown when an invalid value is provided for a command argument.
/// </summary>
public class InvalidValueForArgumentException : CommandArgumentException
{
    public InvalidValueForArgumentException(string argumentName, string value) : base($"Invalid value '{value}' for argument '{argumentName}'")
    {
    }
}