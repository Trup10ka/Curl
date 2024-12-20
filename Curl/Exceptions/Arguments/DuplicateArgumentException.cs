namespace Curl.Exceptions.Arguments;

public class DuplicateArgumentException : CommandArgumentException
{
    public DuplicateArgumentException(string flag) : base($"Duplicate argument: -{flag}")
    {
    }
}