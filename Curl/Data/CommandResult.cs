using Curl.Exceptions.Commands;

namespace Curl.Data;

public class CommandResult
{
    public string? Result { get; }
    
    public bool Success { get; }
    
    public Func<ErrorDuringCommandExecutionException>? ErrorCallback { get; }
    
    public CommandResult(string? result = null, bool success = true, Func<ErrorDuringCommandExecutionException>? errorCallback = null)
    {
        Result = result;
        Success = success;
        ErrorCallback = errorCallback;
    }
}

