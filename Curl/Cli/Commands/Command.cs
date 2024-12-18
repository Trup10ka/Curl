using Curl.Data.Commands;

namespace Curl.Cli.Commands;

public interface ICommand<T> : ICommand
{
    new CommandResult<T> Execute(string argsNotParsed);
}

public interface ICommand
{
    CommandType CommandType { get; }
    
    CommandResult Execute(string argsNotParsed);
}

public abstract class Command<T> : ICommand<T>
{
    public CommandType CommandType { get; }
    
    protected Command(CommandType commandType)
    {
        CommandType = commandType;
    }

    public abstract CommandResult<T> Execute(string argsNotParsed);
    
    CommandResult ICommand.Execute(string argsNotParsed)
    {
        return Execute(argsNotParsed);
    }
}