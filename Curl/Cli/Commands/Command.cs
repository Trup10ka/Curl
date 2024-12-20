using Curl.Data;

namespace Curl.Cli.Commands;

/// <summary>
/// Represents an abstract base class for commands that can be executed.
/// </summary>
public abstract class Command
{
    public CommandType CommandType { get; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Command"/> class with the specified command type.
    /// </summary>
    /// <param name="commandType">The type of the command.</param>
    protected Command(CommandType commandType)
    {
        CommandType = commandType;
    }

    /// <summary>
    /// Executes the command with the specified raw arguments.
    /// </summary>
    /// <param name="argsNotParsed">A string containing the raw arguments for the command.</param>
    /// <returns>A <see cref="CommandResult"/> representing the result of the command execution.</returns>
    public abstract CommandResult Execute(string argsNotParsed);
}
