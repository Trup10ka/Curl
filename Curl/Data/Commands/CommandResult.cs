using Curl.Exceptions.Commands;

namespace Curl.Data.Commands;

public class CommandResult<T> : CommandResult
{
    public CommandResult(T result, Func<ErrorDuringCommandExecutionException>? errorCallback = null)
    {
        Result = result;
        ErrorCallback = errorCallback;
    }

    public T? Result { get; }
    public Func<ErrorDuringCommandExecutionException>? ErrorCallback { get; }
}

public class CommandResult
{
    internal CommandResult()
    {
    }
}
