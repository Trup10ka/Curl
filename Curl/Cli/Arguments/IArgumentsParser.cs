using CommandType = Curl.Cli.Commands.CommandType;

namespace Curl.Cli.Arguments;

public interface IArgumentsParser
{
    Dictionary<string, string?> ParseArguments(CommandType command, string[] args);
}