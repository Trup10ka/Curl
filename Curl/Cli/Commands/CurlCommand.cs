using Curl.Data.Commands;

namespace Curl.Cli.Commands;

public class CurlCommand : Command
{
    public CurlCommand(CommandType commandType) : base(commandType)
    {
    }

    public override CommandResult Execute(string argsNotParsed)
    {
        return new CommandResult("Curl command executed");
    }
}