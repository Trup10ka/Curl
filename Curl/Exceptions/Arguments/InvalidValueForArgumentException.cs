namespace Curl.Exceptions.Arguments;

public class InvalidValueForArgumentException : CommandArgumentException
{
    public InvalidValueForArgumentException(string argumentName, string value) : base($"Invalid value '{value}' for argument '{argumentName}'")
    {
    }
}