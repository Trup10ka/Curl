
using Curl.Cli.Commands;

namespace Curl.Exceptions.Arguments;

public class EmptyArgumentsException : CommandArgumentException
{
    public EmptyArgumentsException(CommandType command) : base("No required arguments provided for command: " + command)
    {
    }
}