namespace Curl.Exceptions.Arguments;

public class UnknownArgumentException : CommandArgumentException
{
    public UnknownArgumentException(string flag) : base($"Unknown argument: -{flag}")
    {
    }
}