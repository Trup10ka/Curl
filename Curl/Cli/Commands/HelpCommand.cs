namespace Curl.Cli.Commands;

using Data;
using static CommandType;
using static Utils.CommandUtils;

using Config = Curl.Data.Config;
public class HelpCommand : Command
{
    private Config Config { get; }

    private string CommandHelpText { get; }

    private Dictionary<CommandType, string> CommandHelpMessages { get; }  = new();
    
    public HelpCommand(CommandType commandType, Config config) : base(commandType)
    {
        Config = config;
        CommandHelpText = Config.SimpleHelpText;
        CommandHelpMessages.Add(CURL, Config.CurlHelpText);
    }

    /// <summary>
    /// Executes the Help command and returns help information based on the provided arguments.
    /// </summary>
    /// <param name="argsNotParsed">The raw argument string containing the name of the command to get help for.</param>
    /// <returns>
    /// A <see cref="CommandResult"/> containing the appropriate help message or an error message.
    /// </returns>
    public override CommandResult Execute(string argsNotParsed)
    {
        if (argsNotParsed == string.Empty)
        {
            return new CommandResult(result: CommandHelpText, success: true);
        }
        
        var args = argsNotParsed.Split(' ');
        if (args.Length > 1)
        {
            return new CommandResult(result: "Invalid number of arguments", success: false);
        }
        
        var command = MatchCommandType(args[0]);
        return command switch
        {
            CURL => new CommandResult(result: CommandHelpMessages[CURL], success: true),
            _ => new CommandResult(result: $"Invalid argument for called command: '{args[0]}'", success: false)
        };
    }
}