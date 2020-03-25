using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thomerson.Gatlin.Core.Midware
{
    /// <summary>
    /// 注册服务
    /// </summary>
    public static class IOCMidware
    {
        public static IServiceCollection AddIOCMidware(this IServiceCollection services)
        {
            //services.AddSingleton(typeof(IBaseRepository), new BaseRepository());
            return services;
        }
    }

}
