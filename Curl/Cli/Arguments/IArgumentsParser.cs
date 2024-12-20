using CommandType = Curl.Cli.Commands.CommandType;

namespace Curl.Cli.Arguments;

/// <summary>
/// Interface for parsing command-line arguments into a dictionary of flags and their corresponding values.
/// </summary>
public interface IArgumentsParser
{
    /// <summary>
    /// Parses the provided command-line arguments into a dictionary of flags and their associated values.
    /// </summary>
    /// <param name="command">The type of command being executed.</param>
    /// <param name="args">An array of arguments passed to the command.</param>
    /// <returns>A dictionary where keys are argument flags (e.g., "l" from "-l") and values are their associated argument values.</returns>
    Dictionary<string, string?> ParseArguments(CommandType command, string[] args);
}