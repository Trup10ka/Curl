using Curl.Data.Commands;

namespace Curl.Cli.Commands;

public class HelpCommand : Command<string>
{
    public HelpCommand(CommandType commandType) : base(commandType)
    {
        
    }

    public override CommandResult<string> Execute(string argsNotParsed)
    {
        throw new NotImplementedException();
    }
}