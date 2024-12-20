namespace Curl.Exceptions.Arguments;

public class CommandArgumentException : Exception
{
    protected CommandArgumentException(string message = "Exception occured when executing a command") : base(message)
    {
    }
}