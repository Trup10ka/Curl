using Curl.Cli.Arguments;
using Curl.Data;
using Curl.Exceptions.Arguments;

namespace Curl.Cli.Commands;

public class CurlCommand : Command
{
    
    private readonly IArgumentsParser _argumentsParser = new StrictPairArgumentParser(canHaveNoArguments: true);
    
    public CurlCommand(CommandType commandType) : base(commandType)
    {
    }

    public override CommandResult Execute(string argsNotParsed)
    {
        if (string.IsNullOrWhiteSpace(argsNotParsed))
        {
            return new CommandResult(result: "No URL provided", success: false);
        }

        var argsTrimmed = argsNotParsed.Trim();
        var splitUrl = argsTrimmed.Split(' ');
        var url = splitUrl[0].Trim();
        
        RemoveFirstArgument(ref splitUrl);
        
        Dictionary<string, string?> parsedArgs;
        try
        {
            parsedArgs = _argumentsParser.ParseArguments(CommandType, splitUrl);
            CheckValidityOfArguments(parsedArgs);
        }
        catch (CommandArgumentException argException)
        {
            return new CommandResult(argException.Message, false);
        }
        
        return FetchContent(url, parsedArgs);
    }

    private static CommandResult FetchContent(string url, Dictionary<string, string?> commandArguments)
    {
        try
        {
            var content = FetchUrlContentAsync(url, commandArguments).GetAwaiter().GetResult();
            return content;
        }
        catch (Exception ex)
        {
            return new CommandResult(result: $"Error: {ex.Message}", success: false);
        }
    }

    private static async Task<CommandResult> FetchUrlContentAsync(string url, Dictionary<string, string?> commandArguments)
    {
        try
        {
            var content = await GetContentAsync(url, commandArguments);

            if (commandArguments.TryGetValue("L", out var limitValue) && int.TryParse(limitValue, out var limit))
            {
                ReduceContent(ref content, limit);
            }
            
            return commandArguments.TryGetValue("O", out var fileName)
                ? WriteOutputToFile(content, fileName!) 
                : new CommandResult(result: content, success: true);
        }
        catch (Exception ex)
        {
            return new CommandResult(result: $"{ex.Message}", success: false);
        }
    }
    
    private static async Task<string> GetContentAsync(string url, Dictionary<string, string?> commandArguments)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
    
    private static void ReduceContent(ref string content, int limit)
    {
        if (content.Length > limit)
        {
            content = string.Concat(content.AsSpan(0, limit), "...");
        }
    }
    
    private static CommandResult WriteOutputToFile(string content, string fileName)
    {
        try
        {
            File.WriteAllText(fileName, content);
        }
        catch (Exception e)
        {
            return new CommandResult(e.Message, false);
        }
        return new CommandResult("Content written to file");
    }
    
    private static void CheckValidityOfArguments(Dictionary<string, string?> arguments)
    {
        foreach (var argument in arguments)
        {
            switch (argument.Key)
            {
                case "L":
                    if (!int.TryParse(argument.Value, out _))
                        throw new InvalidValueForArgumentException(argument.Key, argument.Value!);
                    break;
                case "O":
                    break;
                default:
                    throw new UnknownArgumentException(argument.Key);
            }
        }
    }
    
    private static void RemoveFirstArgument(ref string[] args)
    {
        var list = args.ToList();
        list.RemoveAt(0);
        args = list.ToArray();
    }
}