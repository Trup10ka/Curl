using Curl.Cli.Commands;

namespace Curl.Utils;

public static class CommandUtils
{
    public static Command? MatchCommand(string input, Dictionary<CommandType, Command> commands)
    {
        var commandType = Enum.Parse<CommandType>(input, true);
        return commands.GetValueOrDefault(commandType);
    }
    
    public static CommandType? MatchCommandType(string input)
    {
        if (Enum.TryParse<CommandType>(input, true, out var type))
        {
            return type;
        }
        return null;
    }
}