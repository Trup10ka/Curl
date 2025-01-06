using System.Text.Json;
using System.Text.Json.Serialization;

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
        return JsonSerializer.Serialize(this);
    }
}

[JsonSerializable(typeof(Config))]
public partial class CurlJsonContext : JsonSerializerContext
{
}