using System.Text.Json;
using Curl.Data;

namespace Curl.Config;

using Config = Curl.Data.Config;

/// <summary>
/// A file-based configuration loader that reads and deserializes configuration from a JSON file.
/// </summary>
public class FileConfigLoader : IConfigLoader
{
    
    private string FilePath { get; }
    
    private FileConfigLoader(string filePath)
    {
        FilePath = filePath;
    }
    
    /// <summary>
    /// Loads the configuration from the specified file.
    /// </summary>
    /// <returns>
    /// A <see cref="Config"/> object deserialized from the file content.
    /// </returns>
    /// <exception cref="NullReferenceException">Thrown when the configuration file is empty or deserialization fails.</exception>
    public Config LoadConfig()
    {
        var fileContent = File.ReadAllText(FilePath);

        var config = JsonSerializer.Deserialize<Config>(fileContent, CurlJsonContext.Default.Config);

        if (config == null)
        {
            throw new NullReferenceException("Config file is empty");
        }

        if (string.IsNullOrEmpty(config.SimpleHelpText) || string.IsNullOrEmpty(config.CurlHelpText))
        {
            throw new JsonException("Config file is missing required fields");
        }

        return config;
    }
    
    
    /// <summary>
    /// Creates or initializes a <see cref="FileConfigLoader"/> instance with the specified file path.
    /// </summary>
    /// <param name="path">The path to the configuration file.</param>
    /// <returns>A new <see cref="FileConfigLoader"/> instance.</returns>
    /// <exception cref="FileNotFoundException">
    /// Thrown when the specified configuration file is not found.
    /// A new template configuration file is created at the specified path.
    /// </exception>
    public static FileConfigLoader Init(string path)
    {
        if (File.Exists(path)) return new FileConfigLoader(path);
        
        File.Create(path).Dispose();
        var templateConfig = new Config("General help note", "Curl command help note").ToString();
            
        File.WriteAllText(path, templateConfig);
        throw new FileNotFoundException("Config file not found, creating template config file");
    }
}