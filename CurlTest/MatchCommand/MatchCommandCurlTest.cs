using Curl.Cli.Commands;
using Curl.Data;
using Curl.Utils;

namespace CurlTest.MatchCommand;

[TestFixture]
public class MatchCommandCurlTest
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void TestMatchCurlCommandLowerCase()
    {
        const string simpleHelp = "simple help";
        const string curlHelp = "curl help text";
        
        var commands = new Dictionary<CommandType, Command>
        {
            { CommandType.HELP, new HelpCommand(CommandType.HELP, new Config(simpleHelp, curlHelp)) },
            { CommandType.CURL, new CurlCommand(CommandType.CURL) },
            { CommandType.EXIT, new ExitCommand(CommandType.EXIT) }
        };
        
        var result = CommandUtils.MatchCommand("curl", commands);
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.CommandType.ToString().ToLower(), Is.EqualTo("curl"));
    }
    
    [Test]
    public void TestMatchCurlCommandUpperCase()
    {
        const string simpleHelp = "simple help";
        const string curlHelp = "curl help text";
        
        var commands = new Dictionary<CommandType, Command>
        {
            { CommandType.HELP, new HelpCommand(CommandType.HELP, new Config(simpleHelp, curlHelp)) },
            { CommandType.CURL, new CurlCommand(CommandType.CURL) },
            { CommandType.EXIT, new ExitCommand(CommandType.EXIT) }
        };
        
        var result = CommandUtils.MatchCommand("CURL", commands);
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.CommandType.ToString().ToUpper(), Is.EqualTo("CURL"));
    }
    
    [Test]
    public void TestMatchCurlCommandMixedCase()
    {
        const string simpleHelp = "simple help";
        const string curlHelp = "curl help text";
        
        var commands = new Dictionary<CommandType, Command>
        {
            { CommandType.HELP, new HelpCommand(CommandType.HELP, new Config(simpleHelp, curlHelp)) },
            { CommandType.CURL, new CurlCommand(CommandType.CURL) },
            { CommandType.EXIT, new ExitCommand(CommandType.EXIT) }
        };
        
        var result = CommandUtils.MatchCommand("cUrL", commands);
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.CommandType.ToString().ToLower(), Is.EqualTo("curl"));
    }
}