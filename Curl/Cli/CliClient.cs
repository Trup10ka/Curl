using Curl.Cli.Commands;
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
            
            var command = MatchCommand(input[0]);

            if (command == null)
            {
                ConsoleLogger.LogError($"Unknown command: {input}");
                continue;
            }
            
            input.RemoveAt(0);
            var result = command.Execute(string.Join(' ', input));
            
            
            
            ConsoleLogger.LogInfo(result);
        }
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