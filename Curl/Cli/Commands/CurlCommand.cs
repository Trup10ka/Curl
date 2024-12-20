using Curl.Cli.Arguments;
using Curl.Data;
using Curl.Exceptions.Arguments;

namespace Curl.Cli.Commands;

public class CurlCommand : Command
{
    
    private readonly IArgumentsParser _argumentsParser = new StrictPairArgumentParser(canHaveNoArguments: true);
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CurlCommand"/> class with the specified command type.
    /// </summary>
    /// <param name="commandType">The type of the command (must be <see cref="CommandType.CURL"/>).</param>
    public CurlCommand(CommandType commandType) : base(commandType)
    {
    }

    /// <summary>
    /// Executes the cURL command using the specified raw arguments.
    /// </summary>
    /// <param name="argsNotParsed">The raw arguments as a single string.</param>
    /// <returns>A <see cref="CommandResult"/> representing the result of the execution.</returns>
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
    
    /// <summary>
    /// Sends an HTTP GET request to the specified URL and retrieves the content.
    /// </summary>
    /// <param name="url">The URL to send the request to.</param>
    /// <param name="commandArguments">A dictionary containing command arguments.</param>
    /// <returns>A task representing the asynchronous operation, containing the content as a string.</returns>
    private static async Task<string> GetContentAsync(string url, Dictionary<string, string?> commandArguments)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
    
    /// <summary>
    /// Reduces the length of the content to the specified limit.
    /// </summary>
    /// <param name="content">The content to be reduced.</param>
    /// <param name="limit">The maximum number of characters allowed.</param>
    private static void ReduceContent(ref string content, int limit)
    {
        if (content.Length > limit)
        {
            content = string.Concat(content.AsSpan(0, limit), "...");
        }
    }
    
    /// <summary>
    /// Writes the fetched content to a file.
    /// </summary>
    /// <param name="content">The content to write.</param>
    /// <param name="fileName">The name of the file to write to.</param>
    /// <returns>A <see cref="CommandResult"/> indicating success or failure.</returns>
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
    
    /// <summary>
    /// Validates the parsed command arguments for known flags and proper values.
    /// </summary>
    /// <param name="arguments">The parsed command arguments.</param>
    /// <exception cref="InvalidValueForArgumentException">Thrown when a flag has an invalid value.</exception>
    /// <exception cref="UnknownArgumentException">Thrown when an unknown argument is encountered.</exception>

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