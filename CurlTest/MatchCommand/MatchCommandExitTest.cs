using Curl.Cli.Commands;
using Curl.Data;
using Curl.Utils;

namespace CurlTest.MatchCommand;

[TestFixture]
public class MatchCommandExitTest
{
    [Test]
    public void TestMatchCommandToExitCommandLowerCase()
    {
        const string simpleHelp = "simple help";
        const string curlHelp = "curl help text";
        
        var commands = new Dictionary<CommandType, Command>
        {
            { CommandType.HELP, new HelpCommand(CommandType.HELP, new Config(simpleHelp, curlHelp)) },
            { CommandType.CURL, new CurlCommand(CommandType.CURL) },
            { CommandType.EXIT, new ExitCommand(CommandType.EXIT) }
        };
        
        var result = CommandUtils.MatchCommand("exit", commands);
        Assert.That(result, Is.Not.Null);
    }
    
    [Test]
    public void TestMatchCommandToExitCommandUpperCase()
    {
        const string simpleHelp = "simple help";
        const string curlHelp = "curl help text";
        
        var commands = new Dictionary<CommandType, Command>
        {
            { CommandType.HELP, new HelpCommand(CommandType.HELP, new Config(simpleHelp, curlHelp)) },
            { CommandType.CURL, new CurlCommand(CommandType.CURL) },
            { CommandType.EXIT, new ExitCommand(CommandType.EXIT) }
        };
        
        var result = CommandUtils.MatchCommand("EXIT", commands);
        Assert.That(result, Is.Not.Null);
    }
    
    [Test]
    public void TestMatchCommandToExitCommandMixedCase()
    {
        const string simpleHelp = "simple help";
        const string curlHelp = "curl help text";
        
        var commands = new Dictionary<CommandType, Command>
        {
            { CommandType.HELP, new HelpCommand(CommandType.HELP, new Config(simpleHelp, curlHelp)) },
            { CommandType.CURL, new CurlCommand(CommandType.CURL) },
            { CommandType.EXIT, new ExitCommand(CommandType.EXIT) }
        };
        
        var result = CommandUtils.MatchCommand("eXiT", commands);
        Assert.That(result, Is.Not.Null);
    }
}