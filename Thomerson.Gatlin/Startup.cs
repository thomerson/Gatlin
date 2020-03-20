using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Thomerson.Gatlin.Midware;

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
            //Cookie 设置
            services.AddCookieMidware();

            //跨域设置
            services.AddCorsMidware();

            // 启用Session 默认不启用
            services.AddSession();

            //添加jwt验证：
            services.AddJWTAuthenticationMidware();

            //MVC 配置
            services.AddMvcMidWare();

            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGenMidware();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //添加jwt验证
            app.UseAuthentication();

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

            //Cookie 设置
            app.UseCookieMidware();

            //全局的跨域设置  必须位于UserMvc之前 
            app.UseCORSMidware();

            // MVC Route
            app.UseMvcMidWare();

            app.UseSwaggerGenMidware();
        }
    }
}
