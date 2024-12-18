using Curl.Exceptions.Commands;

namespace Curl.Data.Commands;

public class CommandResult
{
    public string? Result { get; }
    public Func<ErrorDuringCommandExecutionException>? ErrorCallback { get; }
    
    public CommandResult(string result, Func<ErrorDuringCommandExecutionException>? errorCallback = null)
    {
        Result = result;
        ErrorCallback = errorCallback;
    }
}

