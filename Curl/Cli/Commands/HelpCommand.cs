using Curl.Data;
using static Curl.Cli.Commands.CommandType;
using static Curl.Utils.CommandUtils;

namespace Curl.Cli.Commands;

public class HelpCommand : Command
{
    private Dictionary<CommandType, string> _commandHelpMessages = new ()
    { 
        { CURL, """
              Usage: curl <url> [options]

              Options:
              
                -X, --request <command>  Specify request command to use
                -d, --data <data>        HTTP POST data
                -o, --output <file>      Write to file instead of stdout
              """
        }
    };
    
    private const string SimpleHelpMessage = """
                                             Curl is a command line tool for transferring data with URL syntax.

                                             Available commands:
                                             
                                               curl - make a request to a URL
                                                   Usage: curl <url> [options]
                                                   
                                               exit - exit the application
                                               
                                               help - display this message
                                                   Usage: help
                                                          help <command>
                                             """;
    
    public HelpCommand(CommandType commandType) : base(commandType)
    {
    }

    public override CommandResult Execute(string argsNotParsed)
    {
        if (argsNotParsed == string.Empty)
        {
            return new CommandResult(result: SimpleHelpMessage, success: true);
        }
        
        var args = argsNotParsed.Split(' ');
        if (args.Length > 1)
        {
            return new CommandResult(result: "Invalid number of arguments", success: false);
        }
        
        var command = MatchCommandType(args[0]);
        return command switch
        {
            CURL => new CommandResult(result: _commandHelpMessages[CURL], success: true),
            _ => new CommandResult(result: $"Invalid argument for called command: '{args[0]}'", success: false)
        };
    }
}