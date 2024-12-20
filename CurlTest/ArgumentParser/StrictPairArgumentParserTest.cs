using Curl.Cli.Arguments;
using Curl.Cli.Commands;
using Curl.Exceptions.Arguments;

namespace CurlTest.ArgumentParser;

[TestFixture]
public class StrictPairArgumentParserTest
{
    [Test]
    public void ParseArguments_WhenNoArgumentsAndCanHaveNoArgumentsIsFalse_ThrowsEmptyArgumentsException()
    {
        var parser = new StrictPairArgumentParser(false);
        var args = Array.Empty<string>();

        Assert.Throws<EmptyArgumentsException>(Act);
        return;

        void Act() => parser.ParseArguments(CommandType.CURL, args);
    }
    
    [Test]
    public void ParseArguments_WhenNoArgumentsAndCanHaveNoArgumentsIsTrue_ReturnsEmptyDictionary()
    {
        var parser = new StrictPairArgumentParser(true);
        var args = Array.Empty<string>();

        var result = parser.ParseArguments(CommandType.CURL, args);

        Assert.That(result, Is.Empty);
    }
    
    [Test]
    public void ParseArguments_WhenDuplicateArgument_ThrowsDuplicateArgumentException()
    {
        var parser = new StrictPairArgumentParser(true);
        var args = new[] { "-H", "value1", "-H", "value2" };

        Assert.Throws<DuplicateArgumentException>(Act);
        return;

        void Act() => parser.ParseArguments(CommandType.CURL, args);
    }
    
    [Test]
    public void ParseArguments_WhenMissingArgumentValue_ThrowsMissingArgumentValueException()
    {
        var parser = new StrictPairArgumentParser(true);
        var args = new[] { "-H" };

        Assert.Throws<MissingArgumentValueException>(Act);
        return;

        void Act() => parser.ParseArguments(CommandType.CURL, args);
    }
    
    [Test]
    public void ParseArguments_WhenUnknownArgument_ThrowsUnknownArgumentException()
    {
        var parser = new StrictPairArgumentParser(true);
        var args = new[] { "X", "GET" };

        Assert.Throws<UnknownArgumentException>(Act);
        return;

        void Act() => parser.ParseArguments(CommandType.CURL, args);
    }
    
}