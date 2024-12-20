
using Curl.Cli.Commands;

namespace Curl.Exceptions.Arguments;

/// <summary>
/// EmptyArgumentsException represents an exception thrown when no required arguments are provided for a command.
/// </summary>
public class EmptyArgumentsException : CommandArgumentException
{
    public EmptyArgumentsException(CommandType command) : base("No required arguments provided for command: " + command)
    {
    }
}