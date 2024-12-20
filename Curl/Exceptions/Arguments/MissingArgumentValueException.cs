namespace Curl.Exceptions.Arguments;

public class MissingArgumentValueException : CommandArgumentException
{
    public MissingArgumentValueException(string flag) : base($"Missing value for argument: -{flag}")
    {
    }
}