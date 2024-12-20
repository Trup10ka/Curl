namespace Curl.Utils;

using Cli.Commands;

/// <summary>
/// Provides utility methods for handling command-related operations in the CLI application.
/// </summary>
public static class CommandUtils
{
    
    /// <summary>
    /// Matches the input string to a command from the provided dictionary of commands.
    /// </summary>
    /// <param name="input">The command name entered by the user.</param>
    /// <param name="commands">
    /// A dictionary mapping <see cref="CommandType"/> to corresponding <see cref="Command"/> objects.
    /// </param>
    /// <returns>
    /// A <see cref="Command"/> object if the input matches a known command; otherwise, <c>null</c>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="input"/> cannot be parsed into a valid <see cref="CommandType"/>.
    /// </exception>
    public static Command? MatchCommand(string input, Dictionary<CommandType, Command> commands)
    {
        var commandType = Enum.Parse<CommandType>(input, true);
        return commands.GetValueOrDefault(commandType);
    }
    
    /// <summary>
    /// Attempts to parse the input string into a <see cref="CommandType"/>.
    /// </summary>
    /// <param name="input">The command name entered by the user.</param>
    /// <returns>
    /// A nullable <see cref="CommandType"/> if the input matches a known command type; otherwise, <c>null</c>.
    /// </returns>
    public static CommandType? MatchCommandType(string input)
    {
        if (Enum.TryParse<CommandType>(input, true, out var type))
        {
            return type;
        }
        return null;
    }
}