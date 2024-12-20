namespace Curl.Exceptions.Arguments;

/// <summary>
/// Generic exception thrown when an error occurs while executing a command.
/// </summary>
public class CommandArgumentException : Exception
{
    protected CommandArgumentException(string message = "Exception occured when executing a command") : base(message)
    {
    }
}