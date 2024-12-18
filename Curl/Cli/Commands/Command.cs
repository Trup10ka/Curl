using Curl.Data.Commands;

namespace Curl.Cli.Commands;

public abstract class Command
{
    public CommandType CommandType { get; }
    
    protected Command(CommandType commandType)
    {
        CommandType = commandType;
    }

    public abstract CommandResult Execute(string argsNotParsed);
}
