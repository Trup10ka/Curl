using Curl.Cli.Commands;
using Curl.Exceptions.Arguments;

namespace Curl.Cli.Arguments;

public class StrictPairArgumentParser : IArgumentsParser
{
    private bool CanHaveNoArguments { get; }
    
    public StrictPairArgumentParser(bool canHaveNoArguments)
    {
        CanHaveNoArguments = canHaveNoArguments;
    }
    
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