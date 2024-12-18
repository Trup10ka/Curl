using Curl.Data.Commands;

namespace Curl.Cli.Commands;

public class HelpCommand : Command
{
    public HelpCommand(CommandType commandType) : base(commandType)
    {
    }

    public override CommandResult Execute(string argsNotParsed)
    {
        throw new NotImplementedException();
    }
}