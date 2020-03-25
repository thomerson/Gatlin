using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Thomerson.Gatlin.Core.Midware
{
    /// <summary>
    /// Swagger
    /// </summary>
    public static class SwaggerGenMidware
    {
        public static IServiceCollection AddSwaggerGenMidware(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                //Swashbuckle.AspNetCore.Swagger
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Swagger API",
                    Version = "v1",
                    Description = "Gatlin",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "thomerson",
                        Email = string.Empty,
                        Url = "http://www.cnblogs.com/thomerson/"
                    },
                    License = new License
                    {
                        Name = "thomerson",
                        Url = "https://github.com/thomerson/"
                    }
                });

                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(SwaggerGenMidware).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlPath = Path.Combine(basePath, "Thomerson.Gatlin.xml");
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerGenMidware(this IApplicationBuilder app)
        {
            app
                //启用中间件服务生成Swagger作为JSON终结点
                .UseSwagger()
                //启用中间件服务对swagger-ui，指定Swagger JSON终结点
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    //c.RoutePrefix = string.Empty; //设置根路径直接访问SwaggerUI
                });
            return app;
        }
    }
}
