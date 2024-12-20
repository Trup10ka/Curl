namespace Curl.Exceptions.Arguments;

/// <summary>
/// DuplicateArgumentException is thrown when a duplicate argument is provided in a command.
/// </summary>
public class DuplicateArgumentException : CommandArgumentException
{
    public DuplicateArgumentException(string flag) : base($"Duplicate argument: -{flag}")
    {
    }
}