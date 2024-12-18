using Curl.Data.Commands;

namespace Curl.Cli;

public static class ConsoleLogger
{
    public static void LogInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("INFO: ");
        Console.ResetColor();
        Console.WriteLine(message);
    }
    
    public static void LogInfo(CommandResult result)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("INFO: ");
        Console.ResetColor();
        Console.WriteLine(result.Result);
    }
    
    public static void LogWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("WARN: ");
        Console.ResetColor();
        Console.WriteLine(message);
    }

    public static void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("ERROR: ");
        Console.ResetColor();
        Console.WriteLine(message);
    }
}