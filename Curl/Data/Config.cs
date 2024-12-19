using System.Text.Json;

namespace Curl.Data;

public class Config
{
    public string SimpleHelpText { get; init; } 
    
    public string CurlHelpText { get; init; }

    public Config(string simpleHelpText, string curlHelpText)
    {
        SimpleHelpText = simpleHelpText;
        CurlHelpText = curlHelpText;
    }
    
    public override string ToString()
    {
        // I need to return toString in JSON format
        return JsonSerializer.Serialize(this);
    }
}