namespace Curl.Exceptions.Commands;

public class ErrorDuringCommandExecutionException : Exception
{
    public ErrorDuringCommandExecutionException() : base("An error occurred during command execution.")
    {
    }

    public ErrorDuringCommandExecutionException(string message) : base(message)
    {
    }

    public ErrorDuringCommandExecutionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
    