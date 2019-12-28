﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Thomerson.Gatlin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region 跨域设置
            services.AddCors(options =>
            {
                options.AddPolicy("AppDomain", builder =>
                {
                    builder.AllowAnyOrigin() // Allow access to any source from the host
                    .AllowAnyMethod()        // Ensures that the policy allows any method
                    .AllowAnyHeader()        // Ensures that the policy allows any header
                    .AllowCredentials();     // Specify the processing of cookie
                });
            });
            #endregion

            // 启用Session 默认不启用
            services.AddSession();

            services.AddMvc()
                //返回Json字符串格式
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"; // 日期格式化 json数据日期带“T” 格式化
                    options.SerializerSettings.Formatting = Formatting.Indented;  // 返回数据格式缩进(按需配置)
                    options.SerializerSettings.ContractResolver = new NullWithEmptyStringResolver();  // 字段为字符串返回为null时，默认返回空
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(c =>
            {
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
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlPath = Path.Combine(basePath, "Thomerson.Gatlin.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            #region NLog配置
            LogManager.LoadConfiguration($"{ Directory.GetCurrentDirectory()}\\Nlog.config");
            //过时
            //loggerFactory.AddNLog(); // 添加NLog
            //loggerFactory.ConfigureNLog($"{Directory.GetCurrentDirectory()}\\Nlog.config"); // 添加Nlog.config配置文件
            //loggerFactory.AddDebug();
            #endregion

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseCors("AppDomain");//全局的跨域设置

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

            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = string.Empty; //设置根路径直接访问SwaggerUI
            });
        }
    }
}
