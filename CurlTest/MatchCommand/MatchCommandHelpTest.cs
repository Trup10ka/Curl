using Curl.Cli.Commands;
using Curl.Data;
using Curl.Utils;
using CommandType = Curl.Cli.Commands.CommandType;

namespace CurlTest.MatchCommand;

[TestFixture]
public class MatchCommandHelpTest
{
    [Test]
    public void TestMatchCommandToHelpCommandUpperCase()
    {
        const string simpleHelp = "simple help";
        const string curlHelp = "curl help text";
        
        var commands = new Dictionary<CommandType, Command>
        {
            { CommandType.HELP, new HelpCommand(CommandType.HELP, new Config(simpleHelp, curlHelp)) },
            { CommandType.CURL, new CurlCommand(CommandType.CURL) },
            { CommandType.EXIT, new ExitCommand(CommandType.EXIT) }
        };
        
        var result = CommandUtils.MatchCommand("HELP", commands);
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.CommandType.ToString().ToUpper(), Is.EqualTo("HELP"));
    }
    
    
    [Test]
    public void TestMatchCommandToHelpCommandLowerCase()
    {
        const string simpleHelp = "simple help";
        const string curlHelp = "curl help text";
        
        var commands = new Dictionary<CommandType, Command>
        {
            { CommandType.HELP, new HelpCommand(CommandType.HELP, new Config(simpleHelp, curlHelp)) },
            { CommandType.CURL, new CurlCommand(CommandType.CURL) },
            { CommandType.EXIT, new ExitCommand(CommandType.EXIT) }
        };
        
        var result = CommandUtils.MatchCommand("help", commands);
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.CommandType.ToString().ToLower(), Is.EqualTo("help"));
    }
    
    [Test]
    public void TestMatchCommandToHelpCommandMixedCase()
    {
        const string simpleHelp = "simple help";
        const string curlHelp = "curl help text";
        
        var commands = new Dictionary<CommandType, Command>
        {
            { CommandType.HELP, new HelpCommand(CommandType.HELP, new Config(simpleHelp, curlHelp)) },
            { CommandType.CURL, new CurlCommand(CommandType.CURL) },
            { CommandType.EXIT, new ExitCommand(CommandType.EXIT) }
        };
        
        var result = CommandUtils.MatchCommand("hElP", commands);
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.CommandType.ToString().ToLower(), Is.EqualTo("help"));
    }
}