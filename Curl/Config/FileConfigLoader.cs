using System.Text.Json;

namespace Curl.Config;

using Config = Curl.Data.Config;

public class FileConfigLoader : IConfigLoader
{
    
    private string FilePath { get; }
    
    private FileConfigLoader(string filePath)
    {
        FilePath = filePath;
    }
    
    public Config LoadConfig()
    {
        var fileContent = File.ReadAllText(FilePath);

        var config = JsonSerializer.Deserialize<Config>(fileContent);

        if (config == null)
        {
            throw new NullReferenceException("Config file is empty");
        }

        return config;
    }
    
    public static FileConfigLoader Init(string path)
    {
        if (File.Exists(path)) return new FileConfigLoader(path);
        
        File.Create(path).Dispose();
        var templateConfig = new Config("General help note", "Curl command help note").ToString();
            
        File.WriteAllText(path, templateConfig);
        throw new FileNotFoundException("Config file not found, creating template config file");
    }
}