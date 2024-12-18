using Curl.Cli;

namespace Curl;

internal static class Program
{
    public static void Main(string[] args)
    {
        var cliClient = new CliClient();
        cliClient.Init();
        cliClient.Listen();
    }
}