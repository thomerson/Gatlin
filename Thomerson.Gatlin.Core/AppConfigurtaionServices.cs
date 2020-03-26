using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Thomerson.Gatlin.Core
{
    public static class AppConfigurtaionServices
    {
        public static IConfiguration Configuration { get; set; }
        static AppConfigurtaionServices()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }

        public static string GetConnectionString(string connectionName)
        {
            return Configuration.GetConnectionString(connectionName);
        }

        public static string GetRootString(string rootName)
        {
            return Configuration[rootName];
        }

        public static string GetRootLevelString(string rootName, string section)
        {
            return Configuration[$"{rootName}:{section}"];
        }

    }
}
