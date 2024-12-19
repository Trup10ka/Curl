using Curl.Data;

namespace Curl.Cli.Commands;

public class ExitCommand : Command
{
    public ExitCommand(CommandType commandType) : base(commandType)
    {
    }

    public override CommandResult Execute(string argsNotParsed)
    {
        ConsoleLogger.LogWarning("Exiting...");
        Environment.Exit(0);
        return new CommandResult(string.Empty);
    }
}