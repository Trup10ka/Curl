using System.Diagnostics.CodeAnalysis;
using Curl.Config;

namespace Curl.Cli;

using Commands;
using Config = Curl.Data.Config;

using static Utils.CommandUtils;
using static Commands.CommandType;

public class CliClient
{
    private readonly Dictionary<CommandType, Command> _commands = new ();
    
    [SuppressMessage("Performance", "CA1859:Use concrete types when possible for improved performance")]
    private readonly IConfigLoader _configLoader = FileConfigLoader.Init("config.json");
    
    private Config Config { get; set; } = null!;
    
    public void Init()
    {
        Config = _configLoader.LoadConfig();
        InitAllCommands();
        ConsoleLogger.LogInfo("CliClient initialized");
    }

    [SuppressMessage("ReSharper", "FunctionNeverReturns")]
    public void Listen()
    {
        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine()?.Split(' ').ToList();
            
            if (input == null || string.IsNullOrEmpty(input[0])) continue;

            if (TryMatchCommand(input[0], out var command))
            {
                InvokeCommand(command!, input);
            }
        }
    }

    private static void InvokeCommand(Command command, List<string> input)
    {
        input.RemoveAt(0);
        var result = command.Execute(string.Join(' ', input));

        if (result.Success)
        {
            ConsoleLogger.LogInfo(result.Result ?? string.Empty);
        }
        else
        {
            result.ErrorCallback?.Invoke();
            ConsoleLogger.LogError(result.Result ?? string.Empty);
        }
    }
    
    private bool TryMatchCommand(string input, out Command? command)
    {
        var possibleCommand = MatchCommand(input, _commands);
        
        if (possibleCommand == null)
        {
            ConsoleLogger.LogWarning($"Unknown command: {input}");
            command = null;
            return false;
        }

        command = possibleCommand;
        return true;
    }

    private void InitAllCommands()
    {
        var commands = new List<Command>
        {
            new CurlCommand(CURL),
            new HelpCommand(HELP, Config),
            new ExitCommand(EXIT)
        };
        
        commands.ForEach(command => _commands.Add(command.CommandType, command));
    }
}