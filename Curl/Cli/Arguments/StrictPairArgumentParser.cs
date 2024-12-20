using Curl.Cli.Commands;
using Curl.Exceptions.Arguments;

namespace Curl.Cli.Arguments;


/// <summary>
/// A strict parser for command-line arguments that enforces a flag-value pair format.
/// </summary>
public class StrictPairArgumentParser : IArgumentsParser
{
    private bool CanHaveNoArguments { get; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="StrictPairArgumentParser"/> class.
    /// </summary>
    /// <param name="canHaveNoArguments">
    /// Specifies whether the parser allows no arguments.
    /// <c>true</c> if commands can have no arguments; otherwise, <c>false</c>.
    /// </param>
    public StrictPairArgumentParser(bool canHaveNoArguments)
    {
        CanHaveNoArguments = canHaveNoArguments;
    }
    
    /// <summary>
    /// Parses an array of command-line arguments into a strict dictionary of flags and values.
    /// </summary>
    /// <param name="command">The type of command being executed.</param>
    /// <param name="args">An array of command-line arguments.</param>
    /// <returns>
    /// A dictionary where keys are flags (single characters) and values are their associated arguments.
    /// </returns>
    /// <exception cref="EmptyArgumentsException">Thrown when no arguments are provided, and <see cref="CanHaveNoArguments"/> is <c>false</c>.</exception>
    /// <exception cref="DuplicateArgumentException">Thrown when a flag is repeated in the arguments.</exception>
    /// <exception cref="MissingArgumentValueException">Thrown when a flag is missing its associated value.</exception>
    /// <exception cref="UnknownArgumentException">Thrown when an invalid or unknown token is encountered.</exception>
    public Dictionary<string, string?> ParseArguments(CommandType command, string[] args)
    {
        if (args.Length == 0 && !CanHaveNoArguments)
        {
            throw new EmptyArgumentsException(command);
        }

        var strictPairArgs = new Dictionary<string, string?>();

        for (var i = 0; i < args.Length; i++)
        {
            var token = args[i];

            if (token.StartsWith('-') && token.Length == 2)
            {
                var flag = token[1].ToString();

                if (strictPairArgs.ContainsKey(flag))
                    throw new DuplicateArgumentException(flag);
                
                if (i + 1 < args.Length && !args[i + 1].StartsWith('-'))
                {
                    strictPairArgs[flag] = args[i + 1];
                    i++;
                }
                else
                    throw new MissingArgumentValueException(flag);
            }
            else
                throw new UnknownArgumentException(token);
        }

        return strictPairArgs;
    }
}