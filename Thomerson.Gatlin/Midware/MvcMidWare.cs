using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Thomerson.Gatlin.Midware
{
    public static class MvcMidWare
    {
        public static IServiceCollection AddMvcMidWare(this IServiceCollection services)
        {
            services.AddMvc()
                //返回Json字符串格
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"; // 日期格式化 json数据日期带“T” 格式化
                    options.SerializerSettings.Formatting = Formatting.Indented;  // 返回数据格式缩进(按需配置)
                    options.SerializerSettings.ContractResolver = new NullWithEmptyStringResolver();  // 字段为字符串返回为null时，默认返回空
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return services;
        }


        public static IApplicationBuilder UseMvcMidWare(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                // 自定义路由
                routes.MapRoute(
                  name: "default1",
                  template: "api/{controller}/{action}/{id?}",
                  defaults: new { controller = "Values", action = "Index" });

                // 默认路由
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            return app;
        }
    }
}
