using Curl.Cli.Commands;
using Curl.Data.Commands;
using static Curl.Cli.Commands.CommandType;

namespace Curl.Cli;

public class CliClient
{
    private readonly Dictionary<CommandType, Command> _commands = new ();
    
    private bool _isRunning = true;

    public void Init()
    {
        InitAllCommands();
        ConsoleLogger.LogInfo("CliClient initialized");
    }

    public void Listen()
    {
        while (_isRunning)
        {
            Console.Write("> ");
            var input = Console.ReadLine()?.Split(' ').ToList();
            
            if (input == null) continue;

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
        var possibleCommand = MatchCommand(input);
        
        if (possibleCommand == null)
        {
            ConsoleLogger.LogWarning($"Unknown command: {input}");
            command = null;
            return false;
        }

        command = possibleCommand;
        return true;
    }
    
    private Command? MatchCommand(string input)
    {
        var commandType = Enum.Parse<CommandType>(input, true);
        return _commands.GetValueOrDefault(commandType);
    }

    private void InitAllCommands()
    {
        var commands = new List<Command>
        {
            new HelpCommand(HELP),
            new ExitCommand(EXIT)
        };
        
        commands.ForEach(command => _commands.Add(command.CommandType, command));
    }
}