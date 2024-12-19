
namespace Curl.Config;

using Config = Curl.Data.Config;

public interface IConfigLoader
{
    Config LoadConfig();
}