using Curl.Data.Commands;

namespace Curl.Cli.Commands;

public class ExitCommand : ICommand
{
    public CommandType CommandType { get; }
    
    public ExitCommand(CommandType commandType)
    {
        CommandType = commandType;
    }

    public CommandResult Execute(string argsNotParsed)
    {
        ConsoleLogger.LogError("Exiting application...");
        return new CommandResult();
    }
}