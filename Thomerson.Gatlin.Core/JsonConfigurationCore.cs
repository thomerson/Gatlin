using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;

namespace Thomerson.Gatlin.Core
{
    public static class JsonConfigurationCore
    {
        /// <summary>
        /// json 配置读取
        /// </summary>
        /// <returns></returns>
        public static T GetAppSettings<T>(string key, string path = "appsettings.json") where T : class, new()
        {
            var currentClassDir = Directory.GetCurrentDirectory();
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(currentClassDir)
                .Add(new JsonConfigurationSource { Path = path, Optional = false, ReloadOnChange = true })
                .Build();
            var appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appconfig;
        }


    }
}
